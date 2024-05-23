using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using WpfApp_ShoppingAppProject.Models;

namespace WpfApp_ShoppingAppProject.DataBases;

public static class AppDbContext
{
    public static string FolderName { get; set; } = "../../../JsonFiles";

    #region AdminDb

    public static Admin? Admin { get; set; } = new Admin("Zibeyda", "Musayeva", "musayevazibeyd@gmail.com", "+994553968192", new DateTime(2003, 12, 30), "Admin123");

    public static void AdminSaveChanges()
    {
        if(!Directory.Exists(FolderName)) Directory.CreateDirectory(FolderName);

        string fileName = FolderName + "/Admin.json";

        if (!File.Exists(fileName))
            File.Create(fileName).Close();

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;

        string jsonAdmin = JsonSerializer.Serialize(Admin,options);
        File.WriteAllText(fileName, jsonAdmin);
    }


    #endregion

    #region CustomerDb

    public static ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

    public static void CustomerSaveChanges()
    {
        if (!Directory.Exists(FolderName)) Directory.CreateDirectory(FolderName);

        string fileName = FolderName + "/Customers.json";

        if (!File.Exists(fileName))
            File.Create(fileName).Close();

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;

        string jsonCustomers = JsonSerializer.Serialize(Customers,options);
        File.WriteAllText(fileName, jsonCustomers);
    }

    public static bool RemoveCustomerById(Guid id)
    {
        var customer = Customers.FirstOrDefault(x => x.ID == id);

        if (customer is not null)
        {
            Customers.Remove(customer);
            CustomerSaveChanges();
            return true;
        }

        return false;
    }

    #endregion


    #region Products

    public static ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

    public static void ProductSaveChanges()
    {
        if (!Directory.Exists(FolderName)) Directory.CreateDirectory(FolderName);

        string fileName = FolderName + "/Products.json";

        if (!File.Exists(fileName))
            File.Create(fileName).Close();

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;

        string jsonProducts = JsonSerializer.Serialize(Products, options);
        File.WriteAllText(fileName, jsonProducts);
    }

    public static bool RemoveProductById(Guid id)
    {
        var product = Products.FirstOrDefault(x => x.ProductId == id);

        if (product is not null)
        {
            Products.Remove(product);
            ProductSaveChanges();
            return true;
        }

        return false;
    }

    #endregion


    #region Orders

    public static ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();

    public static void OrderSaveChanges()
    {
        if (!Directory.Exists(FolderName)) Directory.CreateDirectory(FolderName);

        string fileName = FolderName + "/Orders.json";

        if (!File.Exists(fileName))
            File.Create(fileName).Close();

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;

        string jsonOrders = JsonSerializer.Serialize(Orders, options);
        File.WriteAllText(fileName, jsonOrders);
    }

    public static bool RemoveOrderById(Guid id)
    {
        var order = Orders.FirstOrDefault(x => x.OrderId == id);

        if (order is not null)
        {
            Orders.Remove(order);
            OrderSaveChanges();
            return true;
        }

        return false;
    }
    #endregion


    #region ReadFromFile

    public static void ReadFromFile()
    {
        if (!Directory.Exists(FolderName))
            Directory.CreateDirectory(FolderName);

        string fileName = FolderName + "/Admin.json";

        if (File.Exists(fileName))
        {
            string jsonAdmin = File.ReadAllText(fileName);
            Admin = JsonSerializer.Deserialize<Admin>(jsonAdmin);

        }


        fileName = FolderName + "/Customers.json";

        if (File.Exists(fileName))
        {
            string jsonCustomers = File.ReadAllText(fileName);
            var myList = JsonSerializer.Deserialize<ObservableCollection<Customer>>(jsonCustomers);
            Customers = new();
            foreach (var customer in myList)
                Customers.Add(customer);
        }

        fileName = FolderName + "/Products.json";


        if (File.Exists(fileName))
        {
            string jsonProducts = File.ReadAllText(fileName);
            var myList = JsonSerializer.Deserialize<ObservableCollection<Product>>(jsonProducts);

            foreach (var item in myList)
                Products.Add(item);
        }


        fileName = FolderName + "/Orders.json";


        if (File.Exists(fileName))
        {
            string jsonOrders = File.ReadAllText(fileName);
            var myList = JsonSerializer.Deserialize<ObservableCollection<Order>>(jsonOrders);

            foreach (var item in myList)
                Orders.Add(item);
        }
    }
    #endregion


}
