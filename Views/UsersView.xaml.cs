using OdemAdmin.Models;
using OdemAdmin.ViewModels;
using OdemAdmin.Windows;
using Syncfusion.Maui.DataGrid;

namespace OdemAdmin.Views;

public partial class UsersView
{
    public UsersView()
    {
        InitializeComponent();
    }

    private void SfDataGrid_OnCellDoubleTapped(object? sender, DataGridCellDoubleTappedEventArgs e)
    {
        var client = (sender as SfDataGrid)?.SelectedRow as Client;
        Navigation.PushAsync(new UserInformationsPage(client,BindingContext as UsersViewModel));
    }
}