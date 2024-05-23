using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class ShoppingCartPAgeViewModel : BaseViewModel
{
    private Customer currentCustomer;

    public Customer CurrentCustomer { get => currentCustomer; set { currentCustomer = value; OnPropertyChanged(); } }

    public ShoppingCartPAgeViewModel()
    {
        PurchaseCommand = new RelayCommand(PurchaseCommandExecute);
    }

    #region PurchaseCommadnSection

    public ICommand PurchaseCommand { get; set; }

    private void PurchaseCommandExecute(object obj)
    {

    }

    #endregion

}
