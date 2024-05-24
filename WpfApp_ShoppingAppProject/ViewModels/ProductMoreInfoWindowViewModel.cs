using System.Windows;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class ProductMoreInfoWindowViewModel : BaseViewModel
{
    private Product currentProduct;
    private Customer currentCustomer;

    public Product CurrentProduct { get => currentProduct; set { currentProduct = value; OnPropertyChanged(); } }

    public Customer CurrentCustomer { get => currentCustomer; set { currentCustomer = value; OnPropertyChanged(); } }

    public ProductMoreInfoWindowViewModel()
    {
        BackCommand = new RelayCommand(BackCommandExecute);
        AddToCartCommand = new RelayCommand(AddToCartCommandExecute);
    }

    #region BackCommandSection
    public ICommand BackCommand { get; set; }

    private void BackCommandExecute(object obj)
    {
        var window = obj as Window;
        window?.Close();
    }
    #endregion

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
}
