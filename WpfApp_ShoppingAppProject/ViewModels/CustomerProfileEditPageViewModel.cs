using System.Text.RegularExpressions;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.ViewModels;
public class CustomerProfileEditPageViewModel : BaseViewModel
{
    private Customer editCustomer;
    private Customer copyEditCustomer = new();

    public Customer EditCustomer { get => editCustomer; set { editCustomer = value; OnPropertyChanged(); } }

    public Customer CopyEditCustomer { get => copyEditCustomer; set { copyEditCustomer = value; OnPropertyChanged(); } }

    public CustomerProfileEditPageViewModel()
    {
        BackCommand = new RelayCommand(BackCommandExecute);
        SaveCommand = new RelayCommand(SaveCommandExecute, CanSaveCommandExecute);
    }

    #region SaveCommandSection

    public ICommand SaveCommand { get; set; }

    public bool CanSaveCommandExecute(object obj)
    {
        string pattern = @"^[A-Za-z0-9_.]+@gmail\.[A-Za-z]+$";
        Regex regex = new Regex(pattern);
        if (CopyEditCustomer.PersonName?.Length > 2 && CopyEditCustomer.PhoneNumber?.Length > 2 && CopyEditCustomer?.Surname?.Length > 2
            && regex.IsMatch(CopyEditCustomer?.Email) &&
            CopyEditCustomer.Password?.Length > 3 && !EditCustomer.Equals(CopyEditCustomer))
            return true;

        return false;
    }

    public void SaveCommandExecute(object obj)
    {
        EditCustomer.SetValue(CopyEditCustomer);
        AppDbContext.CustomerSaveChanges();
    }

    #endregion

}
