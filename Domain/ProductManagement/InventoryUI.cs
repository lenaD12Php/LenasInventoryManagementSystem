using LenaInventoryManagementSystem.Domain;

namespace LenaInventoryManagementSystem;

public class InventoryUI 
{
    public static void DisplayMainMenu()
    {
        Console.WriteLine(" -------------------------- ");
        Console.WriteLine("| Select the action wanted |");
        Console.WriteLine(" -------------------------- ");
        Console.WriteLine("| 1: Add a new product     |");
        Console.WriteLine("| 2: View all products     |");
        Console.WriteLine("| 3: Update a product      |");
        Console.WriteLine("| 4: Delete a product      |");
        Console.WriteLine("| 5: View a product        |");
        Console.WriteLine("| 6: Exit                  |");
        Console.WriteLine(" -------------------------- ");
    }

    public static void DisplayAllProducts()
    {
         var products = Inventory.GetAllProducts(); 
         foreach (Product product in products)
             Console.WriteLine(product.AllDetails()); 

         Inventory.MainMenu();
    }

    public static void AddingANewProductUI()
    {
        var noOfProducts = int.Parse(Message("How many Products do you want to add? "));

        for (int i = 0; i < noOfProducts; i++)
        {
            var name = Message($"Enter the name of the {i + 1}. product you want to add: ");
            var price = double.Parse(Message("Enter the price of the product: "));
            var quantity = int.Parse(Message("Enter the quantity you want to add: "));

            Inventory.AddProduct(name, price, quantity);
        }

        Inventory.MainMenu();
    }

    public static void DeletingAProductUI()
    {
        var noOfProducts = int.Parse(Message("How many products do you want to delete?"));

        for (int i = 0; i < noOfProducts; i++)
        {
            var name = Message($"Enter the {i + 1}. product name you want to delete: ");

            try
            {
                Inventory.DeleteProduct(name);
                PrintMessage($"Product: {name}, was successfully deleted.");
            }
            catch (Exception ex)
            {
                PrintMessage(ex.Message);
            }
        }

        Inventory.MainMenu();
    }

    public static void UpdateProductUI()
    {
        var productName = Message("Enter the product name: ");
        DisplayProductUpdateMenu();
        var userInput = UserSelection();
        var choice = Enum.Parse(typeof(ProductUpdateMenu), userInput, true);

        try
        {
            Inventory.UpdateProduct(productName, (ProductUpdateMenu)choice);
            PrintMessage("Product updated successfully.");
        }
        catch (Exception ex)
        {
            PrintMessage(ex.Message);
        }
        
        Inventory.MainMenu();
    }

    public static void UpdateProductNameUI()
    {
        var name = Message("Enter the product name you want to change: ");
        var newName = Message("Enter the new name: ");

        var product = Inventory.GetProductByName(name);  
        if (product != null)
        {
            Inventory.UpdateProductName(product, newName);  
            PrintMessage("Product name updated successfully.");
        }
        else
            PrintMessage("Product not found.");
        
        Inventory.MainMenu();
    }

    public static void UpdateProductPriceUI()
    {
        var name = Message("Enter the product name you want to change its price: ");
        var newPrice = double.Parse(Message("Enter the new price: "));

        var product = Inventory.GetProductByName(name);
        if (product != null)
        {
            Inventory.UpdateProductPrice(product, newPrice);
            PrintMessage("Product price updated successfully.");
        }
        else
            PrintMessage("Product not found.");

        Inventory.MainMenu();
    }

    public static void UpdateProductQuantityUI()
    {
        var name = Message("Enter the product name you want to change its quantity: ");
        var newQuantity = int.Parse(Message("Enter the new quantity: "));

        var product = Inventory.GetProductByName(name);
        if (product != null)
        {
            Inventory.UpdateProductQuantity(product, newQuantity);
            PrintMessage("Product quantity updated successfully.");
        }
        else
            PrintMessage("Product not found.");

        Inventory.MainMenu();
    }

    public static void DisplayProductUpdateMenu()
    {
        Console.WriteLine(" -------------------------------- ");
        Console.WriteLine("| What do you want to update?    |");
        Console.WriteLine(" -------------------------------- ");
        Console.WriteLine("| 1: Update the product name     |");
        Console.WriteLine("| 2: Update the product price    |");
        Console.WriteLine("| 3: Update the product quantity |");
        Console.WriteLine("| 4: Exit to the main menu       |");
        Console.WriteLine(" -------------------------------- ");
    }

    public static void ViewAProductUI()
    {
        var noOfProducts = int.Parse(Message("How many products do you want to view their details?"));
        for (int i = 0; i < noOfProducts; i++)
        {
            var name = Message($"Enter the name of product {i + 1} to view its details: ");
            var product = Inventory.GetProductByName(name);

            if (product != null)
                PrintMessage(Inventory.ViewAProduct(product));
            else
                PrintMessage($"Product: {name}, doesn't exist. Please try again.");
        }

        Inventory.MainMenu();
    }

    public static string UserSelection()
    {
        Console.WriteLine("Selected: ");
        return Console.ReadLine();
    }

    public static void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static string Message(string input)
    {
        Console.WriteLine(input);
        return Console.ReadLine();
    }
}
