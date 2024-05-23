using System.Collections.ObjectModel;
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

        if(item is not null)
        {
            CurrentCustomer.FavouriteProducts.Add(item);
            AppDbContext.CustomerSaveChanges();
        }
    }

    #endregion

    #region AddToCartCommandSection

    public ICommand AddToCartCommand{ get; set; }

    private void AddToCartCommandExecute(object obj)
    {
        var item= obj as Product;

        if( item is not null )
        {
            CurrentCustomer.MyShoppingCart.Add(item);
            AppDbContext.CustomerSaveChanges(); 
        }
    }

    #endregion

    #region MoreInfoCommandSection

    public ICommand MoreInfoCommand { get; set; }

    private void MoreInfoCommandExecute(object obj)
    {
        //var product = obj as Product;
        //if (product is null) return;
        //var window = App.Container.GetInstance<EditProductWindowView>();
        //var datacontext = App.Container.GetInstance<EditProductWindowViewModel>();
        //datacontext.EditProduct = product;
        //datacontext.CopyEditProduct.SetValue(product);
        //window.DataContext = datacontext;
        //window.ShowDialog();
    }

    #endregion
}
