using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ServerApp
{
    public class ClientConnection
    {
        public TcpClient Tcp { get; }
        public StreamReader Reader { get; }
        public StreamWriter Writer { get; }
        public string Id { get; } // remote endpoint

        public DateTime ConnectedAt { get; } = DateTime.Now;

        public ClientConnection(TcpClient tcp)
        {
            Tcp = tcp;
            var ns = tcp.GetStream();
            Reader = new StreamReader(ns, Encoding.UTF8);
            Writer = new StreamWriter(ns, Encoding.UTF8) { AutoFlush = true };
            Id = tcp.Client.RemoteEndPoint?.ToString() ?? Guid.NewGuid().ToString();
        }

        public Task SendAsync(ResponsePacket packet)
        {
            // Mỗi packet 1 dòng -> ReadLineAsync() bên client/server
            var json = JsonSerializer.Serialize(packet);
            return Writer.WriteLineAsync(json);
        }

        public void Close()
        {
            try { Tcp.Close(); } catch { }
        }
    }
}
