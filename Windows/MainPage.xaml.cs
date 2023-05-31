using OdemAdmin.Views;

namespace Odem.Admin.Windows;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void ExitButton_OnClicked(object sender, EventArgs e)
    {
        Application.Current?.CloseWindow(Application.Current.MainPage!.Window);
    }

    private void Users_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new UsersView());
    }

    private void Transactions_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new TransactionsView());
    }

    private void Tickets_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new TicketsView());
    }
}