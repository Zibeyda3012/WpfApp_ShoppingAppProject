using System.Collections.ObjectModel;
using WpfApp_ShoppingAppProject.Services;

namespace WpfApp_ShoppingAppProject.Models;

public class Product : NotificationService, IEquatable<Product>,ICloneable
{
    private Guid productId;
    private string? productName;
    private string? description;
    private double price;
    private double volume;
    private int quantity;
    private string status;
    private string? imageUrl = "../../Images/default.png";

    public Guid ProductId { get => productId; set => productId = value; }

    public string? ProductName
    {
        get => productName;
        set
        {
            if (value is not null && value.Length > 0)
                productName = value;

            OnPropertyChanged();
        }
    }

    public string? Description
    {
        get => description;
        set
        {
            if (value is not null && value.Length > 0)
                description = value;

            OnPropertyChanged();
        }
    }

    public double Price
    {
        get => price;
        set
        {
            if (value > 0) price = value;
            OnPropertyChanged();
        }
    }


    public double Volume
    {
        get => volume;
        set
        {
            if (value > 0) volume = value;
            OnPropertyChanged();
        }
    }

    public int Quantity
    {
        get => quantity;
        set
        {
            if (value > 0) quantity = value;
            OnPropertyChanged();
        }
    }

    public string Status
    {
        get => status;
        set { status = value; OnPropertyChanged(); }
    }

    public string? ImageUrl { get => imageUrl; set { imageUrl = value; OnPropertyChanged(); } }


    public Product()
    { this.ProductId = Guid.NewGuid(); }

    public Product(Guid ProductId, string? ProductName, string? Description, double Price, double Volume, int Quantity, string Status, string ImageUrl):this()
    {
        this.ProductName = ProductName;
        this.Description = Description;
        this.Price = Price;
        this.Volume = Volume;
        this.Quantity = Quantity;
        this.Status = Status;
        this.ImageUrl = ImageUrl;
    }

    public void SetValue(Product? product)
    {
        ProductId = product.ProductId;
        ProductName = product?.ProductName;
        Description = product?.Description;
        Price = product.Price;
        Volume = product.Volume;
        Quantity = product.Quantity;
        Status = product.Status;
        ImageUrl = product?.ImageUrl;
    }   

    public bool Equals(Product? other)
    {
        if (other is null)
            return false;

        return this.productName == other.ProductName && this.Description == other.Description && this.Price == other.Price && this.Volume == other.Volume && this.Quantity == other.Quantity && this.Status == other.Status && this.ImageUrl == other.ImageUrl;
    }

    public object Clone()
    {
        return new Product
        {
            ProductId = this.ProductId,
            ProductName = this.ProductName,
            Description = this.Description,
            Price = this.Price,
            Volume = this.Volume,
            Quantity = this.Quantity,
            Status = this.Status,
            ImageUrl = this.ImageUrl
        };
    }
}
