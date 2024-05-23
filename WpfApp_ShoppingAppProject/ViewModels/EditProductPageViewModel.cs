using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class EditProductPageViewModel : BaseViewModel
{
    private Product editProduct;
    private Product copyEditProduct;

    public Product EditProduct { get => editProduct; set { editProduct = value; OnPropertyChanged(); } }

    public Product CopyEditProduct { get => copyEditProduct; set { copyEditProduct = value; OnPropertyChanged(); } }

    public EditProductPageViewModel()
    {
        BackCommand = new RelayCommand(BackCommandExecute);
        SaveCommand = new RelayCommand(SaveCommandExecute, CanSaveCommandExecute);
        SelectProductImageCommand = new RelayCommand(SelectProductImageCommandExecute);

    }

    #region SaveCommandSection

    public ICommand SaveCommand { get; set; }

    public bool CanSaveCommandExecute(object obj)
    {
        return EditProduct is not null && !EditProduct.Equals(CopyEditProduct);
    }

    public void SaveCommandExecute(object obj)
    {
        EditProduct.SetValue(CopyEditProduct);
        AppDbContext.ProductSaveChanges();
    }

    #endregion

    #region SelectProductImageSection

    public ICommand SelectProductImageCommand { get; set; }

    public void SelectProductImageCommandExecute(object? obj)
    {
        CopyEditProduct.ImageUrl = GetImage();
    }

    #endregion


}
