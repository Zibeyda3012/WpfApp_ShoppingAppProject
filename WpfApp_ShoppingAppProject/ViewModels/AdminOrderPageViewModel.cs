using System.Collections.ObjectModel;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class AdminOrderPageViewModel : BaseViewModel
{
    private ObservableCollection<Order> orders;

    public ObservableCollection<Order> Orders { get => orders; set { orders = value; OnPropertyChanged(); } }
    public AdminOrderPageViewModel()
    {
     
    }
}
