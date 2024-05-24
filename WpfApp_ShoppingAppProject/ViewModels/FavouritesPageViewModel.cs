using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class FavouritesPageViewModel : BaseViewModel
{
    private Customer currentCustomer;

    public Customer CurrentCustomer { get => currentCustomer; set { currentCustomer = value; OnPropertyChanged(); } }

    public FavouritesPageViewModel()
    {
        AddToCartCommand = new RelayCommand(AddToCartCommandExecute);
        RemoveCommand = new RelayCommand(RemoveCommandExecute);
    }

    #region AddToCartCommandSection

    public ICommand AddToCartCommand { get; set; }

    private void AddToCartCommandExecute(object obj)
    {
        var item = obj as Product;
        if (item is not null)
        {
            AppDbContext.CurrentCustomer.MyShoppingCart.Add(item);
            AppDbContext.CustomerSaveChanges();
        }
    }

    #endregion

    #region RemoveCommandSection
    public ICommand RemoveCommand { get; set; }

    private void RemoveCommandExecute(object obj)
    {
        var item = obj as Product;
        if (item is not null)
        {
            AppDbContext.CurrentCustomer.FavouriteProducts.Remove(item);
            AppDbContext.CustomerSaveChanges();
        }
    }
    #endregion
}
