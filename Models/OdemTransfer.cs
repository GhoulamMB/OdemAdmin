namespace OdemAdmin.Models;

public class OdemTransfer
{
    public required string Id { get; init; }
    public required double Amount { get; init; }
    public DateTime Date { get; init; }
    public required TransactionType Type { get; init; }
    public required Wallet From { get; init; }
    public required Wallet To { get; init; }
}

public enum TransactionType
{
    Ongoing,
    Outgoing,
}