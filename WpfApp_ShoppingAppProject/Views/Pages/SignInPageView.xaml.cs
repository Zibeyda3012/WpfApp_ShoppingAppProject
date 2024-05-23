using System.Windows.Controls;
using WpfApp_ShoppingAppProject.ViewModels;

namespace WpfApp_ShoppingAppProject.Views.Pages;


public partial class SignInPageView : Page
{
    public SignInPageView()
    {
        InitializeComponent();
        DataContext = App.Container?.GetInstance<SignInPageViewModel>();
    }

}
