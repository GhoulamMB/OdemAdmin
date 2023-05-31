using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OdemAdmin.Utils;

namespace OdemAdmin.ViewModels;

public partial class LoginViewModel : ObservableObject
{

    [ObservableProperty]
    private string _email = string.Empty;
    
    [ObservableProperty]
    private string _password = string.Empty;
    
    [ObservableProperty]
    private bool _isLoggedin;

    [RelayCommand]
    private void Login()
    {
        if(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Email)) return;
        var admin = Api.Login(Email, Password).Result;
        if(admin is null)
        {
            IsLoggedin = false;
            return;
        }

        AdminSession.Admin = admin;
        IsLoggedin = true;
        Email = string.Empty;
        Password = string.Empty;
    }
}