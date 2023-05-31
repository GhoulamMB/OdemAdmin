using System.Text;
using Newtonsoft.Json;
using OdemAdmin.Models.request;

namespace OdemAdmin.Utils;
using Models;

public static class Api
{
    public static Task<Admin?> Login(string email, string password)
    {
        var requestUri = $"http://85.215.99.211:5000/api/Admin/login?email={email}&password={password}";
        using var client = new HttpClient();
        var response = client.GetAsync(requestUri).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        return Task.FromResult(JsonConvert.DeserializeObject<Admin>(content));
    }

    public static Task<List<Client>?> GetClients()
    {
        var requestUri = $"http://85.215.99.211:5000/api/Admin/clients";
        using var client = new HttpClient();
        var response = client.GetAsync(requestUri).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        return Task.FromResult(JsonConvert.DeserializeObject<List<Client>>(content));
    }

    public static Task<List<OdemTransfer>?> GetTransactions()
    {
        var requestUri = "http://85.215.99.211:5000/api/Admin/transactions";
        using var client = new HttpClient();
        var response = client.GetAsync(requestUri).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        return Task.FromResult(JsonConvert.DeserializeObject<List<OdemTransfer>>(content));
    }

    public static Task<bool> DeleteClient(string email)
    {
        var requestUri = $"http://85.215.99.211:5000/api/Admin?email={email}";
        using var client = new HttpClient();
        var response = client.DeleteAsync(requestUri).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        return Task.FromResult(JsonConvert.DeserializeObject<bool>(content));
    }

    public static Task<bool> UpdateClient(UserRequest client)
    {
        var requestUri = "http://85.215.99.211:5000/api/Admin/update";
        using var httpClient = new HttpClient();
        var response = httpClient.PutAsync(requestUri,
            new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json")).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        return Task.FromResult(JsonConvert.DeserializeObject<bool>(content));
    }
    
    public static Task<Ticket?> CreateTicket(string message, string userEmail, string adminId)
    {
        var requestUri = $"http://85.215.99.211:5000/api/Admin/createticket?message={message}&userEmail={userEmail}&adminId={adminId}";
        using var client = new HttpClient();
        var response = client.PostAsync(requestUri, null).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        return Task.FromResult(JsonConvert.DeserializeObject<Ticket>(content));
    }
    
    public static Task<Ticket?> GetTicket(string ticketId)
    {
        var requestUri = $"http://85.215.99.211:5000/api/Admin/ticket?ticketId={ticketId}";
        
        using var client = new HttpClient();
        var response = client.GetAsync(requestUri).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        return Task.FromResult(JsonConvert.DeserializeObject<Ticket>(content));
    }
    
    public static Task<List<Ticket>?> GetTickets()
    {
        var requestUri = $"http://85.215.99.211:5000/api/Admin/tickets";
        using var client = new HttpClient();
        var response = client.GetAsync(requestUri).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        return Task.FromResult(JsonConvert.DeserializeObject<List<Ticket>>(content));
    }
    
    public static Task<bool> UpdateTicket(string ticketId, string message, string adminId, bool isClientMessage=false)
    {
        var requestUri = $"http://85.215.99.211:5000/api/Admin/updateticket?ticketId={ticketId}&message={message}&adminId={adminId}&isClientMessage={isClientMessage}";
        
        using var client = new HttpClient();
        var response = client.PutAsync(requestUri, null).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        return Task.FromResult(JsonConvert.DeserializeObject<bool>(content));
    }

    public static Task<bool> UpdateTicketStatus(string ticketId, bool close)
    {
        var requestUri = $"http://85.215.99.211:5000/api/Admin/updateticketstatus?ticketId={ticketId}&close={close}";
        using var client = new HttpClient();
        var response = client.PutAsync(requestUri, null).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        return Task.FromResult(JsonConvert.DeserializeObject<bool>(content));
    }
}