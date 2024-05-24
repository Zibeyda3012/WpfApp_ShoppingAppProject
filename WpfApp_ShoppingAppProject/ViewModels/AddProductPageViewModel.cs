using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class AddProductPageViewModel : BaseViewModel
{
    private Product newProduct;

    public Product NewProduct { get => newProduct; set { newProduct = value; OnPropertyChanged(); } }

    public AddProductPageViewModel()
    {
        NewProduct = new Product();
        BackCommand = new RelayCommand(BackCommandExecute);
        AddCommand = new RelayCommand(AddCommandExecute, CanAddCommandExecute);
        SelectProductImageCommand = new RelayCommand(SelectProductImageCommandExecute);
        CancelCommand = new RelayCommand(CancelCommandExecute);
    }

    #region AddProductSection
    public ICommand AddCommand { get; set; }

    public bool CanAddCommandExecute(object? obj)
    {
        return (NewProduct.ProductName != null && NewProduct.Price > 0 && NewProduct.Quantity > 0);
    }

    public void AddCommandExecute(object? obj)
    {
        if (NewProduct.Quantity > 0)
            NewProduct.Status = "In Stock";
        else
            NewProduct.Status = "Out of Stock";

        AppDbContext.Products.Add(NewProduct);
        AppDbContext.ProductSaveChanges();
        NewProduct = new Product();
    }


    #endregion


    #region CancelCommandЫection
    public ICommand CancelCommand { get; set; }
    public void CancelCommandExecute(object?obj)
    {
        NewProduct = new();
    }
    #endregion

    #region SelectProductImageCommandSection
    public ICommand SelectProductImageCommand { get; set; }

    public void SelectProductImageCommandExecute(object? obj)
    {
        NewProduct.ImageUrl = GetImage();
    }


    #endregion
}
