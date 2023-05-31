using OdemAdmin.ViewModels;

namespace OdemAdmin.Views;

public partial class TransactionsView
{
    public TransactionsView()
    {
        InitializeComponent();
        BindingContext = new TransactionsViewModel();
    }
}