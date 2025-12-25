using MailKit;
using MailKit.Security;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HeThongChungKhoan.Program;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HeThongChungKhoan
{
    public partial class Client : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private Thread listenThread;

        public Client()
        {
            InitializeComponent();
            client = new TcpClient();
            while (!client.Connected)
                Thread.Sleep(1000);
                try
                {
                    client.Connect(GlobalSettings.ServerAddress, int.Parse(GlobalSettings.Port));
                }
                catch { }

            stream = client.GetStream();

            listenThread = new Thread(new ThreadStart(ListenForMessages));
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void TimKiem_Click(object sender, EventArgs e)
        {
            int size = (int) numSize.Value;
            DateTime time = DateTime.Parse(dayDate.Value.ToString());
            string formattedDateTime = time.ToString("yyyy-MM-dd HH:mm:ss");
            string email = txtReceiveMail.Text;

            MessageBox.Show(formattedDateTime);


            SendResponse(stream, new {Command = "FETCH_DATA", Payload = new {
                Size = size,
                Date = formattedDateTime,
                Email = email
            } });
        }

        private void SendResponse(NetworkStream ns, object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            byte[] sendData = Encoding.UTF8.GetBytes(json);
            ns.Write(sendData, 0, sendData.Length);
        }

        private void ListenForMessages()
        {
            try
            {
                string message;
                while ((message = reader.ReadLine()) != null)
                {
                    HandleServerMessage(message);
                }
            }
            catch (Exception ex)
            {
                LogMessage("Lost connection to server.");
                LogMessage(ex.Message);
                listenThread?.Abort();
                writer?.Close();
                reader?.Close();
                client?.Close();
            }
        }

        private void HandleServerMessage(string message)
        {
            //dynamic obj = JsonConvert.DeserializeObject(request);
            //if (obj?.action == null)
            //{
            //    SendResponse(ns, new { status = "error", message = "Missing 'action' field" });
            //    return;
            //}
            string[] parts = message.Split(new char[] { '|' }, 4);
            string command = parts[0];
            LogMessage(command);
            switch (command)
            {
                case "MSG":
                case "﻿MSG":
                    LogMessage($"{parts[1]}: {parts[2]}");
                    break;
            }
        }

        private void LogMessage(string message)
        {
        }
        private void btnMail_Click(object sender, EventArgs e)
        {
            
        }
    }
}
