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

    public void UpdateProductUI()
    {
        var productName = Input("Enter the product name: ");
        DisplayProductUpdateMenu();
        int choice = int.Parse(UserSelection());

        try
        {
            Inventory.UpdateProduct(productName, choice);  
            PrintMessage("Product updated successfully.");
        }
        catch (Exception ex)
        {
            PrintMessage(ex.Message); 
        }
    }

    public void UpdateProductNameUI()
    {
        var name = Input("Enter the product name you want to change: ");
        var newName = Input("Enter the new name: ");

        var product = Inventory.GetProductByName(name);  
        if (product != null)
        {
            Inventory.UpdateProductName(product, newName);  
            PrintMessage("Product name updated successfully.");
        }
        else
        {
            PrintMessage("Product not found.");
        }
    }

    public void UpdateProductPriceUI()
    {
        var name = Input("Enter the product name you want to change its price: ");
        var newPrice = double.Parse(Input("Enter the new price: "));

        var product = Inventory.GetProductByName(name);
        if (product != null)
        {
            Inventory.UpdateProductPrice(product, newPrice);
            PrintMessage("Product price updated successfully.");
        }
        else
        {
            PrintMessage("Product not found.");
        }
    }

    public void UpdateProductQuantityUI()
    {
        var name = Input("Enter the product name you want to change its quantity: ");
        var newQuantity = int.Parse(Input("Enter the new quantity: "));

        var product = Inventory.GetProductByName(name);
        if (product != null)
        {
            Inventory.UpdateProductQuantity(product, newQuantity);
            PrintMessage("Product quantity updated successfully.");
        }
        else
        {
            PrintMessage("Product not found.");
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
