using LenaInventoryManagementSystem.Domain;

namespace LenaInventoryManagementSystem;

public class Inventory
{
    private static List<Product> _products = new();

    internal static void MainMenu()
    {
        InventoryUI.DisplayMainMenu();
        var userSelection=InventoryUI.UserSelection();

        switch (userSelection)
        {
             case "1":
                InventoryUI.AddingANewProductUI();
                break;
            case "2":
                InventoryUI.DisplayAllProducts();
                break;
            case "3":
                InventoryUI.UpdateProductUI();
                break;
            case "4":
                InventoryUI.DeletingAProductUI();
                break;
            case "5":
                InventoryUI.ViewProductUI();
                break;
            default:
                InventoryUI.PrintMessage("Invalid selection. Please try again.");
                break;
        }
    }

    internal static void AddProduct(string name, double price, int quantity)
    {
        //Checking if the product exists.
        bool existingProduct = _products.Any(p => p.ProductName == name);

        //Creatng a new product if the product doesn't exists.
        if (quantity <= Product.MaxItemsInStock && quantity > 0)
        {
            var product = new Product(name, price, quantity);
            _products.Add(product);
        }
    }

    internal static List<Product> GetAllProducts()
    {
        return _products;
    }

    internal static void UpdateProduct(string name, ProductUpdateMenu choice)
    {
        Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

        if (existingProduct == null)
            throw new Exception("Product not found");
        switch (choice)
        {
            case ProductUpdateMenu.UpdateProductName:
                var newName = InventoryUI.Message("Enter new name: ");
                if (_products.Any(p => p.ProductName != newName))
                    UpdateProductName(existingProduct, newName);
                else
                    throw new Exception("The new name is taken.");
                break;
            case ProductUpdateMenu.UpdateProductPrice:
                if (double.TryParse(InventoryUI.Message("Enter new price: "), out var newPrice))
                    UpdateProductPrice(existingProduct, newPrice);
                else
                    throw new Exception("Invalid price format.");
                break;
            case ProductUpdateMenu.UpdateProductQuantity:
                if(int.TryParse(InventoryUI.Message("Enter new quantity: "), out var newQuantity))
                    UpdateProductQuantity(existingProduct, newQuantity);
                else
                    throw new Exception("Invalid quantity format.");
                break;
            default:
                throw new InvalidOperationException("Invalid selection");
        }
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

    internal static void DeleteProduct(string name)
    {
        Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

        if (existingProduct != null)
            _products.Remove(existingProduct);
        else
            throw new Exception($"Product: {name}, doesn't exist please try again.");
    }

    internal static string GetProductDetails(Product product)
    {
            return product.GetAllDetails(); 
    }

    internal static Product? GetProductByName(string name)
    {
        return _products.FirstOrDefault(p => p.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
