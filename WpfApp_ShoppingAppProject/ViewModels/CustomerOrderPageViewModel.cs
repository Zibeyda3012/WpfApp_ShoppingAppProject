using System.Collections.ObjectModel;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class CustomerOrderPageViewModel:BaseViewModel
{
    private ObservableCollection<Order> orders=new();
    public ObservableCollection<Order> Orders { get => orders; set  { orders = value;OnPropertyChanged(); }}
    public CustomerOrderPageViewModel()
    {
        
    }


}
