using System.Windows.Controls;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.Models;
using WpfApp_ShoppingAppProject.Services;
using WpfApp_ShoppingAppProject.Views.Pages;
using WpfApp_ShoppingAppProject.Views.Windows;


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
        CurrentView = App.Container!.GetInstance<CustomerAllProductsPageView>();
        CurrentView.DataContext = App.Container.GetInstance<CustomerAllProductsPageViewModel>();

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
        CustomerAllProductsPageView customerAllProductsPageView = App.Container!.GetInstance<CustomerAllProductsPageView>();

        var customerAllProductsPageViewModel = App.Container.GetInstance<CustomerAllProductsPageViewModel>();

        customerAllProductsPageViewModel.CurrentCustomer = CurrentCustomer;
        CurrentView=customerAllProductsPageView;
        CurrentView.DataContext = customerAllProductsPageViewModel;
    }

    #endregion

    #region FavouriteCommandSection
    public ICommand FavouriteCommand { get; set; }

    private void FavouriteCommandExecute(object obj)
    {
        FavouritesPageView favouritePageView = App.Container!.GetInstance<FavouritesPageView>();
        var favouritePageViewModel = App.Container?.GetInstance<FavouritesPageViewModel>();
        favouritePageViewModel!.CurrentCustomer = CurrentCustomer;
        CurrentView = favouritePageView;
        CurrentView!.DataContext = favouritePageViewModel;
    }
    #endregion

    #region ShoppingCartCommandSection
    public ICommand ShoppingCartCommand { get; set; }

    private void ShoppingCartCommandExecute(object obj)
    {
        //CurrentView = App.Container.GetInstance<AllProductsPageView>();
        //CurrentView.DataContext = App.Container.GetInstance<AllProductsPageViewModel>();
    }

    #endregion

    #region ProfileCommandSection

    public ICommand ProfileCommand { get; set; }

    private void ProfileCommandExecute(object obj)
    {

    }
    #endregion

    #region OrderCommandSection

    public ICommand OrderCommand { get; set; }

    private void OrderCommandExecute(object obj)
    {

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
