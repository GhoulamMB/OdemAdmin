namespace OdemAdmin.Models;

public class Ticket
{
    public string Id { get; init; }
    public DateTime CreationDate { get; init; }
    public Status Status { get; set; }
    public DateTime CloseDate { get; set; }
    public required Admin HandledBy { get; set; }
    public required Client CreatedBy { get; init; }
    public List<Message> Messages { get; init; }
}

public class Message
{
    public string Id { get; init; }
    public required string Content { get; set; }
    public DateTime Timestamp { get; set; }
    public bool isClientMessage { get; init; }
}

public enum Status
{
    Open,
    Closed
}