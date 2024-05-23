using System.Windows.Controls;
using WpfApp_ShoppingAppProject.ViewModels;

namespace WpfApp_ShoppingAppProject.Views.Pages
{
    public partial class SignUpPageView : Page
    {
        public SignUpPageView()
        {
            InitializeComponent();
            DataContext=App.Container?.GetInstance<SignUpPageViewModel>();   
        }
    }
}
