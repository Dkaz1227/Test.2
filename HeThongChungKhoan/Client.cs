using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
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
        private CancellationTokenSource _cts;
        private Task _listeningTask;

        public Client()
        {
            InitializeComponent();
            client = new TcpClient();
            _cts = new CancellationTokenSource();

            _ = ConnectAndListenAsync(_cts.Token);
        }

        private async Task ConnectAndListenAsync(CancellationToken ct)
        {
            try
            {
                await client.ConnectAsync(GlobalSettings.ServerAddress, int.Parse(GlobalSettings.Port));
                if (client.Connected)
                {
                    stream = client.GetStream();
                    reader = new StreamReader(stream, Encoding.UTF8);
                    writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

                    _listeningTask = Task.Run(() => ListenForMessagesAsync(ct), ct);
                }
            }
            catch { }
        }

        private void parseGrid(JToken data)
        {
            var Table = new DataTable();
            Table.Columns.Add("StockCode", typeof(string));
            Table.Columns.Add("StockName", typeof(string));
            Table.Columns.Add("ClosePrice", typeof(string));
            Table.Columns.Add("Change", typeof(string));
            Table.Columns.Add("PerChange", typeof(string));

            try
            {
                if (data == null) return;

                if (data is JArray arr)
                {
                    foreach (var item in arr)
                    {
                        Table.Rows.Add(
                            item["StockCode"]?.ToString() ?? string.Empty,
                            item["StockName"]?.ToString() ?? string.Empty,
                            item["ClosePrice"]?.ToString() ?? string.Empty,
                            item["Change"]?.ToString() ?? string.Empty,
                            item["PerChange"]?.ToString() ?? string.Empty
                        );
                    }
                }
                else if (data is JValue)
                {
                }
                else
                {
                    foreach (var item in data)
                    {
                        Table.Rows.Add(
                            item["StockCode"]?.ToString() ?? string.Empty,
                            item["StockName"]?.ToString() ?? string.Empty,
                            item["ClosePrice"]?.ToString() ?? string.Empty,
                            item["Change"]?.ToString() ?? string.Empty,
                            item["PerChange"]?.ToString() ?? string.Empty
                        );
                    }
                }
            }
            catch { }

            if (GridView.InvokeRequired)
            {
                GridView.BeginInvoke((MethodInvoker)(() => GridView.DataSource = Table));
            }
            else
            {
                GridView.DataSource = Table;
            }
        }

        private async void TimKiem_Click(object sender, EventArgs e)
        {
            int size = (int) numSize.Value;
            DateTime time = DateTime.Parse(dayDate.Value.ToString());
            string formattedDateTime = time.ToString("yyyy-MM-dd HH:mm:ss");
            var res = new
            {
                Command = "FETCH_DATA",
                Payload = new
                {
                    Size = size,
                    Date = formattedDateTime
                }
            };
            await SendRequestAsync(JsonConvert.SerializeObject(res));
        }

        private async void GuiMail_Click(object sender, EventArgs e)
        {
            string email = txtReceiveMail.Text;
            int size = (int) numSize.Value;
            DateTime time = DateTime.Parse(dayDate.Value.ToString());
            string formattedDateTime = time.ToString("yyyy-MM-dd HH:mm:ss");

            var res = new
            {
                Command = "SEND_EMAIL",
                Payload = new
                {
                    Size = size,
                    Date = formattedDateTime,
                    Email = email
                }
            };
            await SendRequestAsync(JsonConvert.SerializeObject(res));
        }

        private async Task SendRequestAsync(string jsonRequest)
        {
            try
            {
                if (writer == null)
                    throw new InvalidOperationException("Not connected to server");

                await writer.WriteLineAsync(jsonRequest);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    status = "error",
                    message = $"Không thể kết nối hoặc giao tiếp với server. {ex.Message}"
                };
                LogMessage(JsonConvert.SerializeObject(errorResponse));
            }
        }

        private async Task ListenForMessagesAsync(CancellationToken ct)
        {
            try
            {
                while (!ct.IsCancellationRequested)
                {
                    string message = await reader.ReadLineAsync();
                    if (message == null) break;
                    HandleServerMessage(message);
                }
            }
            catch (Exception ex)
            {
                LogMessage("Mất kết nối với Server.");
                LogMessage(ex.Message);
                try { _cts?.Cancel(); } catch { }
                try { stream?.Close(); } catch { }
                try { client?.Close(); } catch { }
            }
        }

        private void HandleServerMessage(string message)
        {
            dynamic obj = JsonConvert.DeserializeObject(message);
            if (obj == null) return;

            string status = (obj.Status ?? obj.status ?? "").ToString();
            if(status == "Success")
            {
                string type = (obj.Type ?? obj.type ?? "").ToString();
                string timeStamp = (obj.Timestamp ?? obj.timestamp ?? DateTime.Now.ToString()).ToString();
                string timeOnly = DateTime.Parse(timeStamp).TimeOfDay.ToString();
                string mes = (obj.Message ?? obj.message ?? "").ToString();
                JToken data = null;
                try { data = JToken.Parse(JsonConvert.SerializeObject(obj.Data)); } catch { }
                LogMessage($"[{timeOnly}] {mes}");
                switch (type)
                {
                    case "DATA_RESULT":
                        parseGrid(data);
                        break;

                    case "NOTIFICATION":
                        break;
                }
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)(() => MessageBox.Show("Server lỗi")));
                }
                else
                {
                    MessageBox.Show("Server lỗi");
                }
            }
        }

        private void LogMessage(string message)
        {
            try
            {
                if (lstAnoucement.InvokeRequired)
                {
                    lstAnoucement.BeginInvoke((MethodInvoker)(() => lstAnoucement.Items.Add($"{message}")));
                }
                else
                {
                    lstAnoucement.Items.Add($"{message}");
                }
            }
            catch (Exception)
            {

            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                _cts?.Cancel();
                _listeningTask?.Wait(500);
                try { reader?.Close(); } catch { }
                try { writer?.Close(); } catch { }
                try { stream?.Close(); } catch { }
                try { client?.Close(); } catch { }
            }
            catch { }
            base.OnFormClosing(e);
        }
    }
}
