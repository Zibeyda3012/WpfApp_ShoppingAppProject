using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp_ShoppingAppProject.Services;

namespace WpfApp_ShoppingAppProject.ViewModels;

public abstract class BaseViewModel:NotificationService
{
    #region BackCommandSection
    public ICommand BackCommand { get; set; }

    public virtual void BackCommandExecute(object? obj)
    {
        Page? page = obj as Page;
        if (page is not null && page.NavigationService.CanGoBack)
            page.NavigationService.GoBack();
    }

    #endregion


    #region SelectImageSection
    protected string? GetImage()
    {
        var dialog = new OpenFileDialog();
        dialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";

        if (dialog.ShowDialog() == true)
        {
            var originalFileName = dialog.FileName;
            using FileStream originalFile = new FileStream(originalFileName, FileMode.Open);



            var copyFileName =
                Directory.GetCurrentDirectory().Split("\\bin")[0]
                + "\\Images\\"
                + Guid.NewGuid().ToString().Replace("-", "") + Random.Shared.Next(10000, 1000000000) + originalFileName.Split("\\").Last();

            using FileStream copyFile = new FileStream(copyFileName, FileMode.Create);
            originalFile.CopyTo(copyFile);
            copyFile.Close();


            return copyFileName;
        }
        return null;
    }

    #endregion
}
