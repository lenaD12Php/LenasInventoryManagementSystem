namespace LenaInventoryManagementSystem;

public class Product
{
    private string _productName;
    private double _price;
    private int _quantity;
    private const int _maxItemsInStock = 150;

    public Product()
    {
    }
    public Product(string name) 
    {
        _productName = name;
    }
    public Product(string name, double price) : this (name)
    {
        _price = price;
    }
    public Product(string name, int quantity) : this(name)
    {
        _quantity = quantity;
    }
    public Product(string name, double price, int quantity) : this (name, price) 
    {
        _quantity = quantity;
    }

    public string ProductName
    {
        get => _productName;
        set => _productName = value;
    }
    public double Price
    {
        get => _price;
        set => _price = value;
    }
    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    public void IncreaseStock()
    {
        _quantity++;
    }

    public void IncreaseStock(int amount)
    {
        var newStock = _quantity + amount;
        // Checking if there is enough storage for the whole amount to be added.
        if (newStock <= _maxItemsInStock)
            _quantity = newStock;
        else
        {
            _quantity = _maxItemsInStock;
            Console.WriteLine($"Product: {_productName} stock is full, some products couldn't be added.");
        }
    }

    public void DecreaseStock(int amount)
    {
        var newStock = _quantity - amount;
        if (newStock > 0)
            _quantity = newStock;
        else
        {
            _quantity = 0;
            Console.WriteLine($"Product: {_productName} is out of stock.");
        }
    }

    public string AllDetails()
    {
        return $"Product name: {_productName}, price: {_price}, quantity in stock: {_quantity}";
    }
}

