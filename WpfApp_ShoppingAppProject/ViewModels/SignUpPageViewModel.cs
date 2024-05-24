using System.Text.RegularExpressions;
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
        string pattern = @"^[A-Za-z0-9_.]+@gmail\.[A-Za-z]+$";
        Regex regex = new Regex(pattern);
        if (NewCustomer.PersonName?.Length > 2 && NewCustomer.PhoneNumber?.Length > 2 && NewCustomer?.Surname?.Length > 2
            && NewCustomer?.Birthday > DateTime.Now.AddYears(-100) && regex.IsMatch(NewCustomer?.Email) &&
            NewCustomer.Password?.Length>3) return true;
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
