using System.Windows.Controls;
using WpfApp_ShoppingAppProject.ViewModels;

namespace WpfApp_ShoppingAppProject.Services;

public class ChangePageService
{
    public static void ChangePage<TView, TViewModel>(object? obj)
        where TView : Page where TViewModel : BaseViewModel
    {
        Page? page = obj as Page;
        if (page is not null)
        {
            TView? PageView = App.Container?.GetInstance<TView>();
            PageView!.DataContext = App.Container?.GetInstance<TViewModel>();

            page.NavigationService.Navigate(PageView);
        }
    }
}
