using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;
using WpfApp_ShoppingAppProject.Views.Windows;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class CustomerAllProductsPageViewModel : BaseViewModel
{

    private ObservableCollection<Product> products;
    private Customer currentCustomer;
    public Customer CurrentCustomer { get => currentCustomer; set { currentCustomer = value; OnPropertyChanged(); } }

    public ObservableCollection<Product> Products { get => products; set { products = value; OnPropertyChanged(); } }

    public CustomerAllProductsPageViewModel()
    {
        Products = AppDbContext.Products;
        LikeCommand = new RelayCommand(LikeCommandExecute);
        AddToCartCommand = new RelayCommand(AddToCartCommandExecute);
        MoreInfoCommand = new RelayCommand(MoreInfoCommandExecute);
    }

    #region LikeCommandSection

    public ICommand LikeCommand { get; set; }

    private void LikeCommandExecute(object obj)
    {
        var item = obj as Product;

        if (item is not null)
        {

            if (AppDbContext.CurrentCustomer.FavouriteProducts.Any(p => p.ProductId == item.ProductId))
                return;
            AppDbContext.CurrentCustomer.FavouriteProducts.Add(item);
            AppDbContext.CustomerSaveChanges();
        }
    }

    #endregion

    #region AddToCartCommandSection

    public ICommand AddToCartCommand { get; set; }

    private void AddToCartCommandExecute(object obj)
    {
        var item = obj as Product;

        if (item is not null)
        {
            AppDbContext.CurrentCustomer?.MyShoppingCart.Add(item);
            AppDbContext.CustomerSaveChanges();
        }
    }

    #endregion 

    #region MoreInfoCommandSection

    public ICommand MoreInfoCommand { get; set; }

    private void MoreInfoCommandExecute(object obj)
    {

        var product = obj as Product;
        if (product is null) return;
        var window = App.Container.GetInstance<ProductMoreInfoWindowView>();
        var datacontext = App.Container.GetInstance<ProductMoreInfoWindowViewModel>();
        datacontext.CurrentProduct = product;
        datacontext.CurrentCustomer = CurrentCustomer;
        window.DataContext = datacontext;
        window.ShowDialog();
    }

    #endregion
}
