using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdemAdmin.ViewModels;

namespace OdemAdmin.Windows;

public partial class CreateTicketPage : ContentPage
{
    public TicketsViewModel TicketsViewModel { get; }
    
    public CreateTicketPage(TicketsViewModel ticketsViewModel)
    {
        TicketsViewModel = ticketsViewModel;
        InitializeComponent();
    }

    private void SendButton_OnClick(object sender, EventArgs e)
    {
        var message = MessageTextBox.Text;
        var userEmail = ClientIdTextBox.Text;
        var adminId = Utils.AdminSession.Admin?.Uid;
        TicketsViewModel.createTicket(message, userEmail, adminId!);
        Navigation.PopAsync();
    }
}