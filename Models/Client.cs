using OdemAdmin.Models;

namespace OdemAdmin.Models;

public class Client
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Password { get; set; }
    public required Address Address { get; set; }
    public string Uid { get; init; }
    
    public ClientStatus Status { get; set; }
    public Wallet? Wallet { get; set; }

    public List<Ticket>? Tickets { get; set; }
}

public enum ClientStatus
{
    Active=1,
    Disabled=0
}