using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace ServerApp
{
    public partial class FormServer : Form
    {
        private TcpListener? _listener;
        private CancellationTokenSource? _cts;

        private readonly ConcurrentDictionary<string, ClientConnection> _clients = new();
        public FormServer()
        {
            InitializeComponent();
            txtIp.Text = "0.0.0.0";
            txtPort.Text = "9000";

           

            btnStop.Enabled = false;

            btnStart.Click += btnStart_Click;
            btnStop.Click += btnStop_Click;
            btnBroadcast.Click += btnBroadcast_Click;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            IPAddress ip = txtIp.Text == "0.0.0.0"
                ? IPAddress.Any
                : IPAddress.Parse(txtIp.Text);

            int port = int.Parse(txtPort.Text);

            _listener = new TcpListener(ip, port);
            _listener.Start();

            _cts = new CancellationTokenSource();

            Log($"Server started at {ip}:{port}");

            btnStart.Enabled = false;
            btnStop.Enabled = true;

            _ = AcceptLoopAsync(_cts.Token);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            _listener?.Stop();

            foreach (var c in _clients.Values)
                c.Close();

            _clients.Clear();
            lbClients.Items.Clear();

            btnStart.Enabled = true;
            btnStop.Enabled = false;

            Log("Server stopped");
        }

        private async Task AcceptLoopAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                TcpClient tcp;
                try { tcp = await _listener!.AcceptTcpClientAsync(ct); }
                catch { break; }

                var client = new ClientConnection(tcp);
                _clients[client.Id] = client;

                BeginInvoke(() =>
                    lbClients.Items.Add($"{client.Id} | {client.ConnectedAt:HH:mm:ss}")
                );

                Log($"Client connected: {client.Id}");

                _ = HandleClientAsync(client, ct);
            }
        }

        private async Task HandleClientAsync(ClientConnection client, CancellationToken ct)
        {
            try
            {
                while (!ct.IsCancellationRequested && client.Tcp.Connected)
                {
                    var line = await client.Reader.ReadLineAsync();
                    if (string.IsNullOrWhiteSpace(line)) break;

                    var req = JsonSerializer.Deserialize<RequestPacket>(line);
                    if (req == null) continue;

                    if (req.Command == "FETCH_DATA")
                        await HandleFetch(client, req);
                    else if (req.Command == "SEND_EMAIL")
                        await HandleEmail(client, req);
                }
            }
            finally
            {
                _clients.TryRemove(client.Id, out _);
                Log($"Client disconnected: {client.Id}");
                client.Close();
            }
        }

        private async Task HandleFetch(ClientConnection c, RequestPacket r)
        {
            var stocks = await VietstockApi.FetchAsync(r.Payload.Size, r.Payload.Date);

            await c.SendAsync(new ResponsePacket
            {
                Status = "Success",
                Type = "DATA_RESULT",
                Message = "Fetch success",
                Data = stocks,
                Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }

        private async Task HandleEmail(ClientConnection c, RequestPacket r)
        {
            var stocks = await VietstockApi.FetchAsync(r.Payload.Size, r.Payload.Date);
            var file = ReportWriter.WriteCsv(stocks, r.Payload.Date);

            string subject =
                $"Báo cáo thị trường ngày {DateTime.Parse(r.Payload.Date):dd/MM/yyyy}";

            await EmailService.SendAsync(
                r.Payload.Email,
                subject,
                "Đính kèm báo cáo thị trường",
                file);

            await c.SendAsync(new ResponsePacket
            {
                Status = "Success",
                Type = "DATA_RESULT",
                Message = "Email sent",
                Data = new List<object>(),
                Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }

        private async void btnBroadcast_Click(object sender, EventArgs e)
        {
            var packet = new ResponsePacket
            {
                Status = "Success",
                Type = "NOTIFICATION",
                Message = txtBroadcast.Text,
                Data = new List<object>(),
                Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            foreach (var c in _clients.Values)
                await c.SendAsync(packet);

            Log("Broadcast sent");
        }

        private void Log(string s)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action(() => Log(s)));
                return;
            }

            rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {s}\n");
            rtbLog.ScrollToCaret(); // tự cuộn xuống dòng mới
        }
    }
}
