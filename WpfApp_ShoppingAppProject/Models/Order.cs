using System.Collections.ObjectModel;
using WpfApp_ShoppingAppProject.Services;

namespace WpfApp_ShoppingAppProject.Models;

public class Order : NotificationService
{
    private ObservableCollection<Product> myProducts;
    private Customer customer;
    private DateTime orderDate;
    private string location;
    private Guid orderId;
    private double totalPrice;

    public Guid OrderId { get => orderId; set { orderId = value; OnPropertyChanged(); } }

    public ObservableCollection<Product> MyProducts { get => myProducts; set { myProducts = value; OnPropertyChanged(); } }

    public Customer Customer { get => customer; set { customer = value; OnPropertyChanged(); } }

    public DateTime OrderDate { get => orderDate; set { orderDate = value; OnPropertyChanged(); } }

    public string Location { get => location; set { location = value; OnPropertyChanged(); } }

    public double TotalPrice { get => totalPrice; set { totalPrice = value; OnPropertyChanged(); } }

    public Order()
    {
        OrderId = Guid.NewGuid();
    }

    public Order(ObservableCollection<Product> MyProducts, Customer customer, string location, double TotalPrice) : this()
    {
        this.MyProducts = MyProducts;
        Customer = customer;
        OrderDate = DateTime.Now;
        Location = location;
        this.TotalPrice = TotalPrice;
    }
}
