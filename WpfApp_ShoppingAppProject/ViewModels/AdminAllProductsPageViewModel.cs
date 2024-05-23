using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;
using WpfApp_ShoppingAppProject.Views.Pages;
using WpfApp_ShoppingAppProject.Views.Windows;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class AdminAllProductsPageViewModel : BaseViewModel
{
    private ObservableCollection<Product> products;
    private Product selectedProduct;

    public ObservableCollection<Product> Products { get => products; set { products = value; OnPropertyChanged(); } }

    public Product SelectedProduct { get => selectedProduct; set { selectedProduct = value; OnPropertyChanged(); } }


    public AdminAllProductsPageViewModel()
    {
        Products = AppDbContext.Products;
        EditCommand = new RelayCommand(EditCommandExecute);
        DeleteCommand = new RelayCommand(DeleteCommandExecute);
    }

    #region EditCommandSection
    public ICommand EditCommand { get; set; }

    private void EditCommandExecute(object obj)
    {
        var product = obj as Product;
        if (product is null) return;
        var window = App.Container.GetInstance<EditProductWindowView>();
        var datacontext = App.Container.GetInstance<EditProductWindowViewModel>();
        datacontext.EditProduct = product;
        datacontext.CopyEditProduct.SetValue(product);
        window.DataContext = datacontext;
        window.ShowDialog();

    }
    #endregion


    #region DeleteCommand
    public ICommand DeleteCommand { get; set; }

    private void DeleteCommandExecute(object obj)
    {
        var item = obj as Product;
        AppDbContext.RemoveProductById(item.ProductId);
    }
    #endregion
}
