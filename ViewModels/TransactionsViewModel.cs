using CommunityToolkit.Mvvm.ComponentModel;
using OdemAdmin.Models;

namespace OdemAdmin.ViewModels;

public partial class TransactionsViewModel : ObservableObject
{
    [ObservableProperty]
    private List<OdemTransfer>? _transactions;

    public TransactionsViewModel()
    {
        Transactions = Utils.Api.GetTransactions().Result;
    }
}