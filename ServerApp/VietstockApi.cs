using System.Net.Http;
using System.Text.Json;

namespace ServerApp
{
    public static class VietstockApi
    {
        private static readonly HttpClient _http = new HttpClient();

        private const string Url =
            "https://finance.vietstock.vn/data/KQGDThongKeGiaPaging";

        public static async Task<List<StockDto>> FetchAsync(int size, string date)
        {
            // date client gửi dạng: yyyy-MM-dd HH:mm:ss
            DateTime dt = DateTime.Parse(date);
            string d = dt.ToString("dd/MM/yyyy"); // ⚠️ đúng format Vietstock

            var form = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["page"] = "1",
                ["pageSize"] = size.ToString(),
                ["fromDate"] = d,
                ["toDate"] = d
            });

            var req = new HttpRequestMessage(HttpMethod.Post, Url);
            req.Content = form;

            // ⚠️ headers bắt buộc
            req.Headers.Add("User-Agent", "Mozilla/5.0");
            req.Headers.Add("Accept", "*/*");

            using var res = await _http.SendAsync(req);
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            var root = doc.RootElement;
            var data = root[2]; // 🔥 MẢNG THỨ 3

            var list = new List<StockDto>();
            foreach (var item in data.EnumerateArray())
            {
                list.Add(new StockDto
                {
                    StockCode = item.GetProperty("StockCode").GetString() ?? "",
                    StockName = item.GetProperty("StockName").GetString() ?? "",
                    ClosePrice = ReadNumber(item, "ClosePrice"),
                    Change = ReadNumber(item, "Change"),
                    PerChange = ReadNumber(item, "PerChange")
                });
            }
            return list;
        }

        private static decimal ReadNumber(JsonElement e, string prop)
        {
            var p = e.GetProperty(prop);
            if (p.TryGetDecimal(out var d)) return d;
            return (decimal)p.GetDouble();
        }
    }
}
