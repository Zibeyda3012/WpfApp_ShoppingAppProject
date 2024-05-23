using WpfApp_ShoppingAppProject.Services;

namespace WpfApp_ShoppingAppProject.Models;

public class Admin:Person
{
    public Admin()
    {
        
    }
    public Admin(string PersonName, string Surname, string Email, string PhoneNumber, DateTime Birthday, string Password) : base(PersonName, Surname, Email, PhoneNumber, Birthday, Password)
    { }
}
