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
                UpdateAProduct();
                break;
            case "4":
                DeleteAProduct();
                break;
            case "5":
                ViewAProduct();
                break;
            default:
                _inventoryUI.PrintMessage("Invalid selection. Please try again.");
                break;
        }
    }

    internal static void AddANewProduct(string name, double price, int quantity)
    {
        //Checking if the product exists.
        Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

        //Creatng a new product if the product doesn't exists.
        if (quantity <= _maxItemsInStock && quantity > 0)
        {
            var product = new Product(name, price, quantity);
            _products.Add(product);
        }
        MainMenu();
    }

    internal static List<Product> ViewAllProducts()
    {
        return _products;
    }

    private static void UpdateAProduct()
    {
        var noOfProducts = int.Parse(_inventoryUI.Input("How many products do you want to update its data?"));

        for (int i = 0; i < noOfProducts; i++)
        {
            var name = _inventoryUI.Input($"Enter the {i + 1}. product name that you want to update it's details: ");

            Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

            if (existingProduct != null)
            {
                _inventoryUI.DisplayProductUpdateMenu();
                var userSelection = _inventoryUI.UserSelection();

                switch (userSelection)
                {
                    case "1":
                        _inventoryUI.UpdateProductNameUI();
                        break;
                    case "2":
                        _inventoryUI.UpdateProductPriceUI();
                        break;
                    case "3":
                        _inventoryUI.UpdateProductQuantityUI();
                        break;
                    case "4":
                        MainMenu();
                        break;
                    default:
                        _inventoryUI.PrintMessage("Invalid selection, please try again.");
                        break;
                }
            }
            else
                _inventoryUI.PrintMessage("Product not found. Try again.");
        }
        MainMenu();
    }

    internal static void UpdateProductName(string oldName, string newName)
    {
        Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == oldName);

        if (existingProduct != null)
            existingProduct.ProductName = newName;
        else
           throw new Exception("Product not found.");

        MainMenu();
    }

    internal static void UpdateProductPrice(string name, double newPrice)
    {
        Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

        if (existingProduct != null)
            existingProduct.Price = newPrice;
        else
            throw new Exception("Product not found");

        MainMenu();
    }

    internal static void UpdateProductQuantity(string name, int quantity)
    {
        Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

        if (existingProduct != null)
            existingProduct.Quantity = quantity;
        else
            throw new Exception("Product not found.");  

        MainMenu();
    }

    private static void DeleteAProduct()
    {
        var noOfProducts = int.Parse(_inventoryUI.Input("How many products do you want to delete?"));

        for (int i = 0; i < noOfProducts; i++)
        {
            var name =_inventoryUI.Input($"Enter the {i + 1}. product name you want to delete: ");

            Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
                _inventoryUI.PrintMessage($"Product: {name}, was successfully deleted.");
            }
            else
                _inventoryUI.PrintMessage($"Product: {name}, doesn't exist please try again.");
        }
        MainMenu();
    }

    private static void ViewAProduct()
    {
        var noOfProducts = int.Parse(_inventoryUI.Input("How many products do you want to view its data?"));
        for (int i = 0; i < noOfProducts; i++)
        {
            var name = _inventoryUI.Input($"Enter the {i + 1}. product name that you want to view it's details: ");

            Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

            if (existingProduct != null)
                _inventoryUI.PrintMessage(existingProduct.AllDetails());
            else
                _inventoryUI.PrintMessage($"Product: {name}, doesn't exist please try again.");
        }
        MainMenu();
    }
}
