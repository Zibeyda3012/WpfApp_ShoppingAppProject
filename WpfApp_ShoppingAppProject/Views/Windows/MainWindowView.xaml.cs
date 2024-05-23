using System.Windows.Navigation;
using WpfApp_ShoppingAppProject.ViewModels;

namespace WpfApp_ShoppingAppProject.Views.Windows;

public partial class MainWindowView : NavigationWindow
{
    public MainWindowView()
    {
        InitializeComponent();
        DataContext = App.Container.GetInstance<MainWindowViewModel>();
    }
}
