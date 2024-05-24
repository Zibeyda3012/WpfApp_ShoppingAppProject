using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;
using WpfApp_ShoppingAppProject.Views.Windows;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class AllCustomersPageViewModel : BaseViewModel
{
    private ObservableCollection<Customer> customers;

    public ObservableCollection<Customer> Customers { get => customers; set { customers = value; OnPropertyChanged(); } }
    public AllCustomersPageViewModel()
    {
        RemoveCommand=new RelayCommand(RemoveCommandExecute);   
    }

    #region  RemoveCommandSection

    public ICommand RemoveCommand { get; set; } 

    private void RemoveCommandExecute(object obj)
    {
        var person=obj as Customer;

        if (person is not null)
        {
            AppDbContext.Customers.Remove(person);
            AppDbContext.CustomerSaveChanges(); 
        }
    }
    #endregion



}
