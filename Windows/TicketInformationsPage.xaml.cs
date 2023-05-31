using System.ComponentModel;
using System.Runtime.CompilerServices;
using OdemAdmin.Models;
using OdemAdmin.ViewModels;

namespace OdemAdmin.Windows;

public partial class TicketInformationsPage : INotifyPropertyChanged
{
    private List<Message> _messages;
    public List<Message> Messages
    {
        get=> _messages.OrderBy(d=>d.Timestamp).ToList();
        set
        {
            _messages = value;
            OnPropertyChanged();
        }
    }

    private Ticket Tickett { get; set; }
    private TicketsViewModel TicketsViewModel { get; set; }

    public TicketInformationsPage(Ticket ticket)
    {
        InitializeComponent();
        Tickett = ticket;
        Messages = Tickett.Messages;
        BindingContext = this;
        TicketsViewModel = new();
        if(Tickett.Status == Status.Closed)
            SendButton.IsEnabled = false;
    }

    public new event PropertyChangedEventHandler? PropertyChanged;

    private new void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void SendButton_OnClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(messagebox.Text))
            return;
        var message = messagebox.Text;
        TicketsViewModel.updateTicket(Tickett.Id, message, Tickett.HandledBy.Uid, false);
        Tickett = TicketsViewModel.getTicket(Tickett.Id);
        Messages = Tickett.Messages;
        messagebox.Text = "";
        TicketsViewModel.fetchTickets();
        Tickett = TicketsViewModel.getTicket(Tickett.Id);
    }

    private void OpenTicketButton_OnClicked(object? sender, EventArgs e)
    {
        TicketsViewModel.updateTicketStatus(Tickett.Id, false);
        SendButton.IsEnabled = true;
    }

    private void CloseTicketButton_OnClicked(object? sender, EventArgs e)
    {
        TicketsViewModel.updateTicketStatus(Tickett.Id, true);
        SendButton.IsEnabled = false;
    }
    
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        Tickett = TicketsViewModel.getTicket(Tickett.Id);
        Messages = Tickett.Messages;
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
        Tickett = TicketsViewModel.getTicket(Tickett.Id);
        Messages = Tickett.Messages;
    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        base.OnNavigatingFrom(args);
        Tickett = TicketsViewModel.getTicket(Tickett.Id);
        Messages = Tickett.Messages;
    }
}