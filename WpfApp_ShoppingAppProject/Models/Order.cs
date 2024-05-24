using System.Collections.ObjectModel;
using System.IO.Packaging;
using WpfApp_ShoppingAppProject.Services;

namespace WpfApp_ShoppingAppProject.Models;

public class Order : NotificationService
{
    private ObservableCollection<Product> myProducts = new();
    private DateTime orderDate;
    private Guid orderId;
    private double totalPrice;
    private string customerName;
    private string customerSurname;
    private string customerEmail;
    private string customerPhone;

    public string CustomerPhone { get => customerPhone; set { customerPhone = value; OnPropertyChanged(); } }
    public string CustomerEmail { get => customerEmail; set { customerEmail = value; OnPropertyChanged(); } }
    public string CustomerName { get => customerName; set { customerName = value; OnPropertyChanged(); } }

    public string CustomerSurname { get => customerSurname; set { customerSurname = value; OnPropertyChanged(); } }
    public Guid OrderId { get => orderId; set { orderId = value; OnPropertyChanged(); } }

    public ObservableCollection<Product> MyProducts { get => myProducts; set { myProducts = value; OnPropertyChanged(); } }
    public DateTime OrderDate { get => orderDate; set { orderDate = value; OnPropertyChanged(); } }

    public double TotalPrice { get => totalPrice; set { totalPrice = value; OnPropertyChanged(); } }


    public Order()
    {
        OrderId = Guid.NewGuid();
        OrderDate = DateTime.Now;
    }

    public Order(ObservableCollection<Product> MyProducts, string CustomerName,string CustomerSurname,string CustomerEmail, double TotalPrice) : this()
    {
        this.MyProducts = MyProducts;
        this.TotalPrice = TotalPrice;
        this.CustomerName = CustomerName;
        this.customerSurname = CustomerSurname;
        this.CustomerEmail = CustomerEmail;


    }
}
