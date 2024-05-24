using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;
using WpfApp_ShoppingAppProject.Views.Windows;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class ShoppingCartPAgeViewModel : BaseViewModel
{
    private Customer currentCustomer;

    public Customer CurrentCustomer { get => currentCustomer; set { currentCustomer = value; OnPropertyChanged(); } }

    public ShoppingCartPAgeViewModel()
    {
        PurchaseCommand = new RelayCommand(PurchaseCommandExecute, CanPurchaseCommandExecute);
        RemoveCommand = new RelayCommand(RemoveCommandExecute);
    }

    #region PurchaseCommadnSection

    public ICommand PurchaseCommand { get; set; }

    public bool CanPurchaseCommandExecute(object obj)
    {
        return AppDbContext.CurrentCustomer.MyShoppingCart.Count > 0;
    }

    private void PurchaseCommandExecute(object obj)
    {
        CurrentCustomer = AppDbContext.CurrentCustomer;
        var NewOrder = new Order();
        double totalPrice = 0;
        ObservableCollection<Product> myProducts = new();
        foreach (var item in currentCustomer.MyShoppingCart)
        {
            myProducts.Add(item);
            totalPrice += item.Price;

        }

        NewOrder.CustomerPhone = AppDbContext.CurrentCustomer.PhoneNumber;
        NewOrder.CustomerName = AppDbContext.CurrentCustomer.PersonName;
        NewOrder.CustomerSurname = AppDbContext.CurrentCustomer.Surname;
        NewOrder.CustomerEmail = AppDbContext.CurrentCustomer.Email;
        NewOrder.MyProducts = myProducts;
        NewOrder.TotalPrice = totalPrice;
        CurrentCustomer.MyOrders.Add(NewOrder);
        CurrentCustomer.MyShoppingCart = new();
        AppDbContext.Orders.Add(NewOrder);
        AppDbContext.OrderSaveChanges();
        AppDbContext.CustomerSaveChanges();
    }

    #endregion

    public ICommand RemoveCommand { get; set; }
    public void RemoveCommandExecute(object obj)
    {
        var product = obj as Product;
        if (product is null) return;
        AppDbContext.CurrentCustomer.MyShoppingCart.Remove(product);
        AppDbContext.CustomerSaveChanges();
    }


}
