using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class SignUpPageViewModel : BaseViewModel
{
    public SignUpPageViewModel()
    {
        NewCustomer = new Customer();
        BackCommand = new RelayCommand(BackCommandExecute);
        SignUpCommand = new RelayCommand(SignUpCommandExecute, CanSignUpCommandExecute);
    }


    #region SingUpCommandSection
    private Customer newCustomer;
    public Customer NewCustomer { get => newCustomer; set { newCustomer = value; OnPropertyChanged(); } }
    public ICommand SignUpCommand { get; set; }

    public bool CanSignUpCommandExecute(object? obj)
    {
        if (!string.IsNullOrEmpty(NewCustomer.Email) && !string.IsNullOrEmpty(NewCustomer.PersonName) && !string.IsNullOrEmpty(NewCustomer.Surname) && !string.IsNullOrEmpty(NewCustomer.Password) && !string.IsNullOrEmpty(NewCustomer.PhoneNumber))
            return true;
        return false;
    }
    public void SignUpCommandExecute(object? obj)
    {
        AppDbContext.Customers.Add(NewCustomer);
        NewCustomer = new Customer();
        AppDbContext.CustomerSaveChanges();
    }
    #endregion

}
