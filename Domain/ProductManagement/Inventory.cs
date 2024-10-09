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
                _inventoryUI.DisplayAddingANewProduct();
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
        MainMenu();
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
                        UpdateProductName();
                        break;
                    case "2":
                        UpdateProductPrice();
                        break;
                    case "3":
                        UpdateProductQuantity();
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

    private static void UpdateProductName()
    {
        var oldName = _inventoryUI.Input("Please enter the product name that you want to change: ");

        var newName = _inventoryUI.Input("Please enter the new name: ");

        Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == oldName);

        if (existingProduct != null)
            existingProduct.ProductName = newName;
        else
            _inventoryUI.PrintMessage("Product not found, please try again.");

        MainMenu();
    }

    private static void UpdateProductPrice()
    {
        var name = _inventoryUI.Input("Please enter the product name that you want to change its price: ");
        
       var newPrice = double.Parse(_inventoryUI.Input($"Enter the new price of the ({name}) product: "));

        Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

        if (existingProduct != null)
            existingProduct.Price = newPrice;
        else
            _inventoryUI.PrintMessage("Product not found, please try again.");

        MainMenu();
    }

    private static /*int*/void  UpdateProductQuantity(/*string name, int quantity*/)
    {
        //If I add Two parameters one for the name and one for the quantity and handle the logic here.
       var name = _inventoryUI.Input("Please enter the product name that you want to change its quantity: ");

        var quantity = int.Parse(_inventoryUI.Input($"Enter the new quantity of the ({name}) product: "));

        Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

        if (existingProduct != null)
            existingProduct.Quantity = quantity;
        else
            _inventoryUI.PrintMessage("Product not found, please try again.");

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
