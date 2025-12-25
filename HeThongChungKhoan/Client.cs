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
                    if (client.Connected)
                    {
                        stream = client.GetStream();

                        listenThread = new Thread(new ThreadStart(ListenForMessages));
                        listenThread.IsBackground = true;
                        listenThread.Start();
                    }
                }
                catch { }
        }

        private void TimKiem_Click(object sender, EventArgs e)
        {
            int size = (int) numSize.Value;
            DateTime time = DateTime.Parse(dayDate.Value.ToString());
            string formattedDateTime = time.ToString("yyyy-MM-dd HH:mm:ss");
            string email = txtReceiveMail.Text;
            var res = new
            {
                Command = "FETCH_DATA",
                Payload = new
                {
                    Size = size,
                    Date = formattedDateTime,
                    Email = email
                }
            };
            string response = SendRequest(stream, JsonConvert.SerializeObject(res));
            HandleServerMessage(response);
        }

        private string SendRequest(NetworkStream ns, string jsonRequest)
        {
            try
            {
                byte[] requestData = Encoding.UTF8.GetBytes(jsonRequest);
                ns.Write(requestData, 0, requestData.Length);
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    while ((bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    status = "error",
                    message = "Không thể kết nối hoặc giao tiếp với server."
                };
                return JsonConvert.SerializeObject(errorResponse);
            }
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
                LogMessage("Mất kết nối với Server.");
                LogMessage(ex.Message);
                listenThread?.Abort();
                stream?.Close();
                client?.Close();
            }
        }

        private void HandleServerMessage(string message)
        {
            dynamic obj = JsonConvert.DeserializeObject(message);
            string status = obj.Status.ToString();
            if(status == "Success")
            {
                string type = obj.Type.ToString();
                string timeStamp = obj.Timestamp.ToString();
                string timeOnly = DateTime.Parse(timeStamp).TimeOfDay.ToString();
                string mes = obj.Message.ToString();
                LogMessage($"[{timeOnly}] {mes}");
                switch (type)
                {
                    case "DATA_RESULT":
                        break;

                    case "NOTIFICATION":
                        break;
                }
            }
            else
            {
                MessageBox.Show("Server lỗi");
            }
        }

        private void LogMessage(string message)
        {
            try
            {
                lstAnoucement.Items.Add($"{message}\n");
            }
            catch (Exception)
            {

            }
        }

    }
}
