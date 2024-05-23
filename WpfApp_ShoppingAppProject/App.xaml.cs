using SimpleInjector;
using System.Windows;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.ViewModels;
using WpfApp_ShoppingAppProject.Views.Windows;
using WpfApp_ShoppingAppProject.Views.Pages;

namespace WpfApp_ShoppingAppProject;

public partial class App : Application
{
    public static Container? Container { get; set; } = new Container();

    public void RegisterView()
    {
        Container?.RegisterSingleton<MainWindowView>();
        Container?.RegisterSingleton<SignInPageView>();
        Container?.RegisterSingleton<SignUpPageView>();
        Container?.RegisterSingleton<AddProductPageView>();
        Container?.RegisterSingleton<AllCustomersPageView>();
        Container?.RegisterSingleton<AdminAllProductsPageView>();
        Container?.RegisterSingleton<AdminDashboardPageView>();
        Container?.Register<EditProductWindowView>();
        Container?.Register<CustomerProfileEditWindowView>();
        Container?.RegisterSingleton<CustomerDashboardPageView>();
        Container?.RegisterSingleton<AdminProfileEditPageView>();
        Container?.RegisterSingleton<AdminOrderPageView>();
        Container?.RegisterSingleton<CustomerAllProductsPageView>();


    }

    public void RegisterViewModel()
    {
        Container?.RegisterSingleton<MainWindowViewModel>();
        Container?.RegisterSingleton<SignInPageViewModel>();
        Container?.RegisterSingleton<AdminProfileEditPageViewModel>();
        Container?.RegisterSingleton<SignUpPageViewModel>();
        Container?.RegisterSingleton<EditProductPageViewModel>();
        Container?.RegisterSingleton<EditProductWindowViewModel>();
        Container?.RegisterSingleton<AddProductPageViewModel>();
        Container?.RegisterSingleton<AllCustomersPageViewModel>();
        Container?.RegisterSingleton<AdminAllProductsPageViewModel>();
        Container?.RegisterSingleton<AdminDashboardPageViewModel>();
        Container?.RegisterSingleton<CustomerDashboardPageViewModel>();
        Container?.RegisterSingleton<CustomerProfileEditWindowViewModel>();
        Container?.RegisterSingleton<AdminOrderPageViewModel>();
        Container?.RegisterSingleton<CustomerAllProductsPageViewModel>();


    }

    protected override void OnStartup(StartupEventArgs e)
    {

        RegisterView();
        RegisterViewModel();

        MainWindowView? mainWindowView = Container?.GetInstance<MainWindowView>();
        mainWindowView!.DataContext = Container?.GetInstance<MainWindowViewModel>();

        AppDbContext.ReadFromFile();
        mainWindowView.ShowDialog();

        base.OnStartup(e);

        Current.Shutdown();
    }
}
