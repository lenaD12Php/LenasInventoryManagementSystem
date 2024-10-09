namespace LenaInventoryManagementSystem;

public class InventoryUI 
{
    public void DisplayMainMenu()
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

    public void DisplayAllProducts()
    {
         var products = Inventory.ViewAllProducts(); 
         foreach (Product product in products)
         {
             Console.WriteLine(product.AllDetails()); 
         }
         Inventory.MainMenu();
    }

    /*public void DisplayUpdatedProductQuantity()
    {
        var name = Input("Please enter the product name that you want to change its quantity: ");

        var quantity = int.Parse(Input($"Enter the new quantity of the ({name}) product: "));

    }*/

    public void AddingANewProductUI()
    {
        var noOfProducts = int.Parse(Input("How many Products do you want to add? "));

        for (int i = 0; i < noOfProducts; i++)
        {
            var name = Input($"Enter the name of the {i + 1}. product you want to add: ");
            var price = double.Parse(Input("Enter the price of the product: "));
            var quantity = int.Parse(Input("Enter the quantity you want to add: "));

            Inventory.AddANewProduct(name, price, quantity);
        }
    }

    public void UpdateProductNameUI()
    {
        var oldName = Input("Please enter the product name that you want to change: ");
        var newName = Input("Please enter the new name: ");

        try
        {
            Inventory.UpdateProductName(oldName, newName);
            PrintMessage("Product name updated successfully.");
        }
        catch (Exception ex)
        {
            PrintMessage(ex.Message);
        }
    }

    public void UpdateProductQuantityUI()
    {
        var name = Input("Please enter the product name that you want to change its quantity: ");
        var quantity = int.Parse(Input($"Enter the new quantity of the ({name}) product: "));

        try
        {
            Inventory.UpdateProductQuantity(name, quantity); 
            PrintMessage("Product quantity updated successfully.");
        }
        catch (Exception ex)
        {
            PrintMessage(ex.Message);
        }
    }

    public void UpdateProductPriceUI()
    {
        var name = Input("Please enter the product name that you want to change its price: ");
        var newPrice = double.Parse(Input($"Enter the new price of the ({name}) product: "));

        try
        {
            Inventory.UpdateProductPrice(name, newPrice);
            PrintMessage("Product price updated successfully.");
        }
        catch (Exception ex)
        {
            PrintMessage(ex.Message);
        }
    }
  
    public void DisplayProductUpdateMenu()
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

    public string UserSelection()
    {
        Console.WriteLine("Selected: ");
        return Console.ReadLine();
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public string Input(string input)
    {
        Console.WriteLine(input);
        return Console.ReadLine();
    }
}
