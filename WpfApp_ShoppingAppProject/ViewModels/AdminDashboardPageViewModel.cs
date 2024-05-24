using System.Windows.Controls;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Services;
using WpfApp_ShoppingAppProject.Views.Pages;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class AdminDashboardPageViewModel : BaseViewModel
{
    private Page currentView;

    public Page CurrentView
    {
        get { return currentView; }
        set { currentView = value; OnPropertyChanged(); }
    }

    public AdminDashboardPageViewModel()
    {
        CurrentView = App.Container.GetInstance<AdminAllProductsPageView>();
        CurrentView.DataContext = App.Container.GetInstance<AdminAllProductsPageViewModel>();
        HomeCommand = new RelayCommand(HomeCommandExecute);
        CustomerCommand = new RelayCommand(CustomerCommandExecute);
        AddProductCommand = new RelayCommand(AddProductCommandExecute);
        ProfileCommand = new RelayCommand(ProfileCommandExecute);
        OrderCommand = new RelayCommand(OrderCommandExecute);
        LogOutCommand = new RelayCommand(LogOutCommandExecute);
    }

    #region HomeCommandSection
    public ICommand HomeCommand { get; set; }

    private void HomeCommandExecute(object obj)
    {
        CurrentView = App.Container!.GetInstance<AdminAllProductsPageView>();
        CurrentView.DataContext = App.Container.GetInstance<AdminAllProductsPageViewModel>();
    }

    #endregion


    #region CustomerCommandSection

    public ICommand CustomerCommand { get; set; }

    private void CustomerCommandExecute(object obj)
    {
        CurrentView = App.Container!.GetInstance<AllCustomersPageView>();
       var datacontext= App.Container.GetInstance<AllCustomersPageViewModel>();
        datacontext.Customers = AppDbContext.Customers;
        CurrentView.DataContext = datacontext;
    }

    #endregion

    #region AddProductCommandSection

    public ICommand AddProductCommand { get; set; }

    private void AddProductCommandExecute(object obj)
    {
        CurrentView = App.Container!.GetInstance<AddProductPageView>();
        CurrentView.DataContext = App.Container.GetInstance<AddProductPageViewModel>();
    }
    #endregion

    #region ProfileCommandSection
    public ICommand ProfileCommand { get; set; }

    private void ProfileCommandExecute(object obj)
    {
        CurrentView = App.Container!.GetInstance<AdminProfileEditPageView>();
        var datacontext = App.Container.GetInstance<AdminProfileEditPageViewModel>();
        datacontext.EditAdmin = AppDbContext.Admin!;
        datacontext.CopyEditAdmin.SetValue(datacontext.EditAdmin);
        CurrentView.DataContext = datacontext;
    }

    #endregion

    #region OrderCommandSection

    public ICommand OrderCommand { get; set; }

    private void OrderCommandExecute(object obj)
    {
        CurrentView = App.Container!.GetInstance<AdminOrderPageView>();
       var datacontext= App.Container.GetInstance<AdminOrderPageViewModel>();
        datacontext.Orders = AppDbContext.Orders;
        CurrentView.DataContext = datacontext;
    }
    #endregion

    #region LogOutCommandSection

    public ICommand LogOutCommand { get; set; }

    private void LogOutCommandExecute(object obj)
    {
        ChangePageService.ChangePage<SignInPageView, SignInPageViewModel>(obj);
    }
    #endregion

}
