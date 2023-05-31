using OdemAdmin.Models;
using OdemAdmin.ViewModels;
using OdemAdmin.Windows;
using Syncfusion.Maui.DataGrid;

namespace OdemAdmin.Views;

public partial class TicketsView
{
    public TicketsView()
    {
        InitializeComponent();
    }

    private void SfDataGrid_OnCellDoubleTapped(object? sender, DataGridCellDoubleTappedEventArgs e)
    {
        var ticket = (sender as SfDataGrid)?.SelectedRow as Ticket;
        Navigation.PushAsync(new TicketInformationsPage(ticket));
    }

    private void CreateTicketButton_OnClick(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreateTicketPage(BindingContext as TicketsViewModel));
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var vm = BindingContext as TicketsViewModel;
        vm?.fetchTickets();
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
        var vm = BindingContext as TicketsViewModel;
        vm?.fetchTickets();
    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        base.OnNavigatingFrom(args);
        var vm = BindingContext as TicketsViewModel;
        vm?.fetchTickets();
    }
}