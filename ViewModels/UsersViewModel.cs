using CommunityToolkit.Mvvm.ComponentModel;
using OdemAdmin.Models;
using OdemAdmin.Models.request;

namespace OdemAdmin.ViewModels;

public partial class UsersViewModel : ObservableObject
{
    [ObservableProperty] private IEnumerable<Client>? _clients;
    [ObservableProperty] private Client? _client;

    public UsersViewModel()
    {
        Clients = Utils.Api.GetClients().Result;
    }

    public void FetchClients()
    {
        Clients = Utils.Api.GetClients().Result;
    }
    
    public void DeleteClient(Client client)
    {
        if (client == null!) return;
        Utils.Api.DeleteClient(client.Email);
        FetchClients();
    }
    
    public void UpdateClient(UserRequest client)
    {
        if (client == null!) return;
        Utils.Api.UpdateClient(client);
        FetchClients();
    }
}