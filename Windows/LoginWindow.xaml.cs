using Odem.Admin.Windows;
using OdemAdmin.ViewModels;

namespace OdemAdmin.Windows;

public partial class LoginWindow : ContentPage
{
    public LoginWindow()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        var vm = BindingContext as LoginViewModel;
        vm!.LoginCommand.Execute(null);
        if (vm.IsLoggedin)
        {
            Navigation.PushAsync(new MainPage());
        }
        else
        {
            Application.Current?.MainPage!.DisplayAlert("Incorrect Login Details","Login Failed","OK");
        }
    }
}