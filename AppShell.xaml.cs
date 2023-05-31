using OdemAdmin.Views;
using OdemAdmin.Windows;

namespace OdemAdmin;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(UserInformationsPage),typeof(UserInformationsPage));
        Routing.RegisterRoute(nameof(UsersView),typeof(UsersView));
    }
}