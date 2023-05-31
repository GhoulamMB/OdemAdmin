using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OdemAdmin.Models;

namespace OdemAdmin.ViewModels;

public partial class TicketsViewModel : ObservableObject
{
    [ObservableProperty]
    private List<Ticket>? _tickets;
    
    public TicketsViewModel()
    {
        fetchTickets();
    }

    internal void fetchTickets()
    {
        Tickets = Utils.Api.GetTickets().Result!;
    }
    
    public void updateTicket(string ticketId,string message, string adminId, bool isClientMessage)
    {
        Utils.Api.UpdateTicket(ticketId, message, adminId, isClientMessage);
        fetchTickets();
    }
    
    public Ticket getTicket(string ticketId)
    {
        return Utils.Api.GetTicket(ticketId).Result!;
    }
    
    public void createTicket(string message, string userEmail, string adminId)
    {
        Utils.Api.CreateTicket(message, userEmail, adminId);
        fetchTickets();
    }

    public void updateTicketStatus(string ticketId, bool close)
    {
        Utils.Api.UpdateTicketStatus(ticketId, close);
        fetchTickets();
    }
}