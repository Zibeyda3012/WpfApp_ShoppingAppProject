using System.Windows;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.ViewModels;
public class EditProductWindowViewModel:BaseViewModel
{
    //private Product product;
    //private Product tempProduct;

    //public Product Product { get => product; set { product = value; OnPropertyChanged(); } }
    //public Product TempProduct { get => tempProduct; set { tempProduct = value; OnPropertyChanged(); } }
    //public EditProductWindowViewModel()
    //{
    //    tempProduct = new();
    //    SaveCommand = new RelayCommand(SaveCommandExecute);
    //    CancelCommand = new RelayCommand(CancelCommandExecute);    
    //}

    //#region SaveCommandSection
    //public ICommand SaveCommand { get; set; }
    //public void SaveCommandExecute(object?obj)
    //{
    //    Product.SetValue(TempProduct);
    //    var window = obj as Window;
    //    window?.Close();
    //}
    //#endregion

    //#region CancelCommandSection
    //public ICommand CancelCommand { get; set; }
    //public void CancelCommandExecute(object?obj)
    //{
    //    var window = obj as Window;
    //    window?.Close();
    //}
    //#endregion

    private Product editProduct;
    private Product copyEditProduct;

    public Product EditProduct { get => editProduct; set { editProduct = value; OnPropertyChanged(); } }

    public Product CopyEditProduct { get => copyEditProduct; set { copyEditProduct = value; OnPropertyChanged(); } }

    public EditProductWindowViewModel()
    {
        CancelCommand = new RelayCommand(CancelCommandExecute);
        SaveCommand = new RelayCommand(SaveCommandExecute, CanSaveCommandExecute);
        SelectProductImageCommand = new RelayCommand(SelectProductImageCommandExecute);
        CopyEditProduct = new();
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
        CancelCommandExecute(obj);
    }

    #endregion

    #region SelectProductImageSection

    public ICommand SelectProductImageCommand { get; set; }

    public void SelectProductImageCommandExecute(object? obj)
    {
        CopyEditProduct.ImageUrl = GetImage();
    }

    #endregion

    #region CancelCommandSection
    public ICommand CancelCommand { get; set; }
    public void CancelCommandExecute(object? obj)
    {
        var window = obj as Window;
        window?.Close();
    }
    #endregion

}
