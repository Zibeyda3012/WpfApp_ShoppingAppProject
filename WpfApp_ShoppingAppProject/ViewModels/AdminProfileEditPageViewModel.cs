using System.Windows.Input;
using WpfApp_ShoppingAppProject.Commands;
using WpfApp_ShoppingAppProject.DataBases;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.ViewModels;

public class AdminProfileEditPageViewModel : BaseViewModel
{
    private Admin editAdmin;
    private Admin copyEditAdmin;

    public Admin EditAdmin { get => editAdmin; set { editAdmin = value; OnPropertyChanged(); } }

    public Admin CopyEditAdmin { get => copyEditAdmin; set { copyEditAdmin = value; OnPropertyChanged(); } }

    public AdminProfileEditPageViewModel()
    {
        CopyEditAdmin = new Admin();
        BackCommand = new RelayCommand(BackCommandExecute);
        SaveCommand = new RelayCommand(SaveCommandExecute,CanSaveCommandExecute);
        CancelCommand = new RelayCommand(CancelCommandExecute);
    }

    #region SaveCommandSection

    public ICommand SaveCommand { get; set; }

    public bool CanSaveCommandExecute(object obj)
    {
        return EditAdmin is not null && !EditAdmin.Equals(CopyEditAdmin);
    }

    public void SaveCommandExecute(object obj)
    {
        EditAdmin.SetValue(CopyEditAdmin);
        AppDbContext.AdminSaveChanges();
    }

    #endregion


    #region CancelCommandSection

    public ICommand CancelCommand { get; set; }
    public void CancelCommandExecute(object obj)
    {
        CopyEditAdmin.SetValue(EditAdmin);
    }
    #endregion

}
