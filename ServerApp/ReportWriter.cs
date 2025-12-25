using System.Text;

public static class ReportWriter
{
    public static string WriteCsv(List<StockDto> stocks, string dateString)
    {
        var dt = DateTime.Parse(dateString);

        var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
        Directory.CreateDirectory(folder);

        var path = Path.Combine(folder, $"Report_{dt:yyyyMMdd_HHmmss}.csv");

        var sb = new StringBuilder();
        sb.AppendLine("StockCode,StockName,ClosePrice,Change,PerChange");

        foreach (var s in stocks)
        {
            sb.AppendLine($"{Esc(s.StockCode)},{Esc(s.StockName)},{s.ClosePrice},{s.Change},{s.PerChange}");
        }

        File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        return path;

        static string Esc(string x)
        {
            if (x.Contains(',') || x.Contains('"'))
                return $"\"{x.Replace("\"", "\"\"")}\"";
            return x;
        }
    }
}
