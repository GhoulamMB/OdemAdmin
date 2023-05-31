using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OdemAdmin.Models;
using OdemAdmin.Models.request;
using OdemAdmin.Utils;

namespace OdemAdmin.ViewModels;

[QueryProperty(nameof(Client),"Client")]
public partial class UserInformationsPageViewModel : ObservableObject
{
    [ObservableProperty] private Client? _client;


    [RelayCommand]
    private Task Save(object parameter)
    {
        var request = parameter as UserRequest;
        if (Api.UpdateClient(request).Result)
        {
            return Task.CompletedTask;
        }
        return null;
    }
    
    [RelayCommand]
    private void Delete()
    {
        Application.Current.MainPage.DisplayAlert("Confirmation", "Do you want to delete the user?", "Yes", "No");
        Api.DeleteClient(Client.Email);
    }
}