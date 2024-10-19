namespace LenaInventoryManagementSystem;

public class Inventory
{
    private static List<Product> _products = new();
    private static InventoryUI _inventoryUI=new();
    private const int _maxItemsInStock = 150;

    internal static void MainMenu()
    {
        _inventoryUI.DisplayMainMenu();
        var userSelection=_inventoryUI.UserSelection();

        switch (userSelection)
        {
             case "1":
                _inventoryUI.AddingANewProductUI();
                break;
            case "2":
                _inventoryUI.DisplayAllProducts();
                break;
            case "3":
                _inventoryUI.UpdateProductUI();
                break;
            case "4":
                _inventoryUI.DeletingAProductUI();
                break;
            case "5":
                _inventoryUI.ViewAProductUI();
                break;
            default:
                _inventoryUI.PrintMessage("Invalid selection. Please try again.");
                break;
        }
    }

    internal static void AddANewProduct(string name, double price, int quantity)
    {
        //Checking if the product exists.
        bool existingProduct = _products.Any(p => p.ProductName == name);

        //Creatng a new product if the product doesn't exists.
        if (quantity <= _maxItemsInStock && quantity > 0)
        {
            var product = new Product(name, price, quantity);
            _products.Add(product);
        }
    }

    internal static List<Product> ViewAllProducts()
    {
        return _products;
    }

    internal static void UpdateProduct(string name, int choice)
    {
        Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

        if (existingProduct != null)
        {
            switch (choice)
            {
                case 1:
                    var newName = _inventoryUI.Input("Enter new name: ");
                    UpdateProductName(existingProduct, newName);
                    break;
                case 2:
                    var newPrice = double.Parse(_inventoryUI.Input("Enter new price: "));
                    UpdateProductPrice(existingProduct, newPrice);
                    break;
                case 3:
                    var newQuantity = int.Parse(_inventoryUI.Input("Enter new quantity: "));
                    UpdateProductQuantity(existingProduct, newQuantity);
                    break;
                default:
                    throw new InvalidOperationException("Invalid selection");
            }
        }
        else
            throw new Exception("Product not found");
    }

    internal static void UpdateProductName(Product product, string newName)
    {
        product.ProductName = newName;  
    }

    internal static void UpdateProductPrice(Product product, double newPrice)
    {
        product.Price = newPrice;  
    }

    internal static void UpdateProductQuantity(Product product, int newQuantity)
    {
        product.Quantity = newQuantity;  
    }

    internal static void DeleteAProduct(string name)
    {
        Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

        if (existingProduct != null)
            _products.Remove(existingProduct);
        else
            throw new Exception($"Product: {name}, doesn't exist please try again.");
    }

    internal static string ViewAProduct(Product product)
    {
            return product.AllDetails(); 
    }

    internal static Product? GetProductByName(string name)
    {
        return _products.FirstOrDefault(p => p.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
