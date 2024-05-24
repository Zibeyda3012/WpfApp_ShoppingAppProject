using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;
using WpfApp_ShoppingAppProject.Views.Pages;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class AdminProfileEditPageViewModel : BaseViewModel
{
    private Admin editAdmin;
    private Admin copyEditAdmin;
    private Page currentView;

    public Admin EditAdmin { get => editAdmin; set { editAdmin = value; OnPropertyChanged(); } }

    public Admin CopyEditAdmin { get => copyEditAdmin; set { copyEditAdmin = value; OnPropertyChanged(); } }

    public Page CurrentView { get => currentView; set { currentView = value; OnPropertyChanged(); } }

    public AdminProfileEditPageViewModel()
    {
        CopyEditAdmin = new Admin();
        SaveCommand = new RelayCommand(SaveCommandExecute, CanSaveCommandExecute);
    }

    #region SaveCommandSection3

    public ICommand SaveCommand { get; set; }

    public bool CanSaveCommandExecute(object obj)
    {
        string pattern = @"^[A-Za-z0-9_.]+@gmail\.[A-Za-z]+$";
        Regex regex = new Regex(pattern);
        if (CopyEditAdmin.PersonName?.Length > 2 && CopyEditAdmin.PhoneNumber?.Length > 2 && CopyEditAdmin?.Surname?.Length > 2
            && CopyEditAdmin?.Birthday > DateTime.Now.AddYears(-100) && regex.IsMatch(CopyEditAdmin?.Email) &&
            CopyEditAdmin.Password?.Length > 3 && EditAdmin is not null && !EditAdmin.Equals(CopyEditAdmin)) return true;
        return false;
    }

    public void SaveCommandExecute(object obj)
    {
        EditAdmin.SetValue(CopyEditAdmin);
        AppDbContext.AdminSaveChanges();
    }

    #endregion


}
