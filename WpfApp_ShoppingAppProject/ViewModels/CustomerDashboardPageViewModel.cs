using System.Windows.Controls;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;
using WpfApp_ShoppingAppProject.Services;
using WpfApp_ShoppingAppProject.Views.Pages;

namespace WpfApp_ShoppingAppProject.ViewModels;
public class CustomerDashboardPageViewModel : BaseViewModel
{
    private Customer currentCustomer;

    public Customer CurrentCustomer { get { return currentCustomer; } set { currentCustomer = value; OnPropertyChanged(); } }

    private Page currentView;

    public Page CurrentView
    {
        get { return currentView; }
        set { currentView = value; OnPropertyChanged(); }
    }

    public CustomerDashboardPageViewModel()
    {
        HomeCommandExecute(null);
        HomeCommand = new RelayCommand(HomeCommandExecute);
        FavouriteCommand = new RelayCommand(FavouriteCommandExecute);
        ShoppingCartCommand = new RelayCommand(ShoppingCartCommandExecute);
        ProfileCommand = new RelayCommand(ProfileCommandExecute);
        OrderCommand = new RelayCommand(OrderCommandExecute);
        LogOutCommand = new RelayCommand(LogOutCommandExecute);
    }

    #region HomeCommandSection
    public ICommand HomeCommand { get; set; }

    private void HomeCommandExecute(object obj)
    {
        CurrentView = App.Container!.GetInstance<CustomerAllProductsPageView>();
        var datacontext = App.Container?.GetInstance<CustomerAllProductsPageViewModel>();
        datacontext!.CurrentCustomer = AppDbContext.CurrentCustomer;
        CurrentView!.DataContext = datacontext;

    }

    #endregion

    #region FavouriteCommandSection
    public ICommand FavouriteCommand { get; set; }

    public void FavouriteCommandExecute(object obj)
    {
        HomeCommandExecute(null);
        FavouritesPageView favouritePageView = App.Container!.GetInstance<FavouritesPageView>();
        var favouritePageViewModel = App.Container?.GetInstance<FavouritesPageViewModel>();
        favouritePageViewModel!.CurrentCustomer = AppDbContext.CurrentCustomer;
        CurrentView = favouritePageView;
        CurrentView!.DataContext = favouritePageViewModel;
    }
    #endregion

    #region ShoppingCartCommandSection
    public ICommand ShoppingCartCommand { get; set; }

    private void ShoppingCartCommandExecute(object obj)
    {
        HomeCommandExecute(obj);

        CurrentView = App.Container.GetInstance<ShoppingCartPageView>();
        var datacontext= App.Container.GetInstance<ShoppingCartPAgeViewModel>();
        datacontext.CurrentCustomer=CurrentCustomer;
        CurrentView.DataContext = datacontext;
    }

    #endregion

    #region ProfileCommandSection

    public ICommand ProfileCommand { get; set; }

    private void ProfileCommandExecute(object obj)
    {
        CurrentView = App.Container.GetInstance<CustomerProfileEditPageView>();
        var datacontext = App.Container.GetInstance<CustomerProfileEditPageViewModel>();
        datacontext.EditCustomer = CurrentCustomer;
        datacontext.CopyEditCustomer.SetValue(CurrentCustomer);
        CurrentView.DataContext = datacontext;
    }
    #endregion

    #region OrderCommandSection

    public ICommand OrderCommand { get; set; }

    private void OrderCommandExecute(object obj)
    {
        CurrentView = App.Container.GetInstance<CustomerOrderPageView>();
        var datacontext = App.Container.GetInstance<CustomerOrderPageViewModel>();
        datacontext.Orders=AppDbContext.CurrentCustomer.MyOrders;
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