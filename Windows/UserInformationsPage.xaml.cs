using OdemAdmin.Models;
using OdemAdmin.Models.request;
using OdemAdmin.ViewModels;

namespace OdemAdmin.Windows;
public partial class UserInformationsPage : ContentPage
{
    public Client Client { get; set; }
    public UsersViewModel ViewModel { get; set; }
    public UserInformationsPage(Client client,UsersViewModel usersViewModel)
    {
        InitializeComponent();
        Client = client;
        BindingContext = Client;
        ViewModel = usersViewModel;
    }

    private void SaveButton_OnClicked(object? sender, EventArgs e)
    {
        var request = new UserRequest()
        {
            Email = EmailTextBox.Text,
            FirstName = FNameTextBox.Text,
            LastName = LNameTextBox.Text,
            Phone = PhoneTextBox.Text
        };
        ViewModel.UpdateClient(request);
        ViewModel.FetchClients();
        Navigation.PopAsync();
    }

    private void DeleteButton_OnClicked(object? sender, EventArgs e)
    {
        App.Current.MainPage.DisplayPromptAsync("Delete Client", "Are you sure you want to delete this client?", "Yes", "No");
        ViewModel.DeleteClient(Client);
        Navigation.PopAsync();
    }

    private void CancelButton_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}