using System.Windows;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class CustomerProfileEditWindowViewModel:BaseViewModel
{
    private Customer editCustomer;
    private Customer copyEditCustomer;

    public Customer EditCustomer { get => editCustomer; set { editCustomer = value; OnPropertyChanged(); } }

    public Customer CopyEditCustomer { get => copyEditCustomer; set { copyEditCustomer = value; OnPropertyChanged(); } }
    public CustomerProfileEditWindowViewModel()
    {
        CancelCommand = new RelayCommand(CancelCommandExecute);
        SaveCommand=new RelayCommand(SaveCommandExecute, CanSaveCommandExecute);
        CopyEditCustomer = new();
    }

    #region SaveCommandSection

    public ICommand SaveCommand { get; set; }

    public bool CanSaveCommandExecute(object obj)
    {
        return EditCustomer is not null && !EditCustomer.Equals(CopyEditCustomer);
    }

    public void SaveCommandExecute(object obj)
    {
        EditCustomer.SetValue(CopyEditCustomer);
        AppDbContext.CustomerSaveChanges();
        CancelCommandExecute(obj);
    }

    #endregion

    #region CancelCommandSection
    public ICommand CancelCommand { get; set; }
    public void  CancelCommandExecute(object?obj)
    {
        var window = obj as Window;
        window?.Close();
    }
    #endregion
}
