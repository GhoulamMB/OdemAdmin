using OdemAdmin.Models;

namespace OdemAdmin.Models;

public class Admin
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Password { get; set; }
    public required Address Address { get; set; }
    public string Uid { get; init; }
    public IList<Ticket>? HandledTickets { get; init; }
}