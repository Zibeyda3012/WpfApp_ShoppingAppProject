using System.Collections.ObjectModel;

namespace WpfApp_ShoppingAppProject.Models;

public class Customer : Person
{
    private Order myOrder;
    private ObservableCollection<Product> favouriteProducts;
    private ObservableCollection<Product> myShoppingCart;

    public Order MyOrder { get => myOrder; set { myOrder = value; OnPropertyChanged(); } }

    public ObservableCollection<Product> FavouriteProducts { get => favouriteProducts; set { favouriteProducts = value; OnPropertyChanged(); } }

    public ObservableCollection<Product> MyShoppingCart { get => myShoppingCart; set { myShoppingCart = value; OnPropertyChanged(); } }

    public Customer() 
    { }

    public Customer(string PersonName, string Surname, string Email, string PhoneNumber, DateTime Birthday, string Password) : base(PersonName, Surname, Email, PhoneNumber, Birthday, Password)
    { }
}
