public class RequestPacket
{
    public string Command { get; set; } = ""; // FETCH_DATA | SEND_EMAIL
    public PayloadDto Payload { get; set; } = new();
}

public class PayloadDto
{
    public int Size { get; set; }
    public string Date { get; set; } = "";   // "yyyy-MM-dd HH:mm:ss"
    public string Email { get; set; } = "";
}

public class ResponsePacket
{
    public string Status { get; set; } = "Success"; // Success | Error
    public string Type { get; set; } = "DATA_RESULT"; // DATA_RESULT | NOTIFICATION
    public string Message { get; set; } = "";
    public object? Data { get; set; } // list stock hoặc empty
    public string Timestamp { get; set; } = "";
}

public class StockDto
{
    public string StockCode { get; set; } = "";
    public string StockName { get; set; } = "";
    public decimal ClosePrice { get; set; }
    public decimal Change { get; set; }
    public decimal PerChange { get; set; }
}
