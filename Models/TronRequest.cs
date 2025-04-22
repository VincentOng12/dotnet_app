namespace TronApiApp.Models;

public class AccountRequest
{
    public string Address { get; set; } = string.Empty;
}

public class TransactionRequest
{
    public string Address { get; set; } = string.Empty;
    public int? Limit { get; set; } = 10;
}

public class TrcRequest
{
    public string? Address { get; set; }
    public int? Limit { get; set; } = 10;
}