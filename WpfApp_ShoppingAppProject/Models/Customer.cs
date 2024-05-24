using System.Collections.ObjectModel;

namespace WpfApp_ShoppingAppProject.Models;

public class Customer : Person
{
    private ObservableCollection<Product> favouriteProducts=new();
    private ObservableCollection<Product> myShoppingCart=new();
    private ObservableCollection<Order> myOrders=new();

    public ObservableCollection<Order> MyOrders { get => myOrders; set { myOrders = value; OnPropertyChanged(); } }

    public ObservableCollection<Product> FavouriteProducts { get => favouriteProducts; set { favouriteProducts = value; OnPropertyChanged(); } }

    public ObservableCollection<Product> MyShoppingCart { get => myShoppingCart; set { myShoppingCart = value; OnPropertyChanged(); } }

    public Customer() 
    { }

    public Customer(string PersonName, string Surname, string Email, string PhoneNumber, DateTime Birthday, string Password) : base(PersonName, Surname, Email, PhoneNumber, Birthday, Password)
    { }
}
