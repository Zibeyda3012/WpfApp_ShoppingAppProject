using System.Media;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Services;
using WpfApp_ShoppingAppProject.Views.Pages;


namespace WpfApp_ShoppingAppProject.ViewModels;

public class SignInPageViewModel : BaseViewModel
{
    private string? errorMassage;
    public string? ErrorMassage { get => errorMassage; set { errorMassage = value; OnPropertyChanged(); } }
    public SignInPageViewModel()
    {

        BackCommand = new RelayCommand(BackCommandExecute);
        SignInCommand = new RelayCommand(SignInCommandExecute);
        SignUpCommand = new RelayCommand(SignUpCommandExecute);
    }

    #region SignInCommandSection
    private string? email;
    private string? password;


    public string? Email { get => email; set { email = value; OnPropertyChanged(); } }
    public string? Password { get => password; set { password = value; OnPropertyChanged(); } }
    public ICommand SignInCommand { get; set; }



    public void SignInCommandExecute(object? obj)
    {
        Page myPage = obj as Page;

        var windowParent = NavigationWindow.GetWindow(myPage);

        if (windowParent != null)
        {
            windowParent.ResizeMode = System.Windows.ResizeMode.CanResize;
        }

        if (Email == "a")
        {
            if (Password == "a")
                ChangePageService.ChangePage<AdminDashboardPageView, AdminDashboardPageViewModel>(obj);

            else
            {
                ErrorMassage = "Incorrect Password";
                return;
            }
        }

        else
        {
            var isLogin = AppDbContext.Customers.Any(a => a.Email == Email);
            if (isLogin)
            {
                var isPassword = AppDbContext.Customers.FirstOrDefault(a => a.Email == Email).Password == Password;
                if (isPassword)
                {
                    var customer = AppDbContext.Customers.FirstOrDefault(a => a.Email == Email);

                    Page? page = obj as Page;
                    CustomerDashboardPageView customerDashboardPageView = App.Container?.GetInstance<CustomerDashboardPageView>()!;

                    var customerDashboardPageViewModel = App.Container?.GetInstance<CustomerDashboardPageViewModel>()!;
                    customerDashboardPageViewModel.CurrentCustomer = customer;

                    customerDashboardPageView.DataContext = customerDashboardPageViewModel;
                    page.NavigationService.Navigate(customerDashboardPageView);
                    //ChangePageService.ChangePage<AdminDashboardPageView, AdminDashboardPageViewModel>(obj);

                }
                else
                {
                    ErrorMassage = "Password is incorrect";
                    return;
                }

            }
            else
                ErrorMassage = "Email is incorrect";
        }

        Email = "";
        Password = "";

    }

    #endregion


    #region SignUpCommandSection

    public ICommand SignUpCommand { get; set; }

    private void SignUpCommandExecute(object? obj)
    {
        ChangePageService.ChangePage<SignUpPageView, SignUpPageViewModel>(obj);
    }

    #endregion

}
