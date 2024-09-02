using LenaInventoryManagementSystem.Domain.ProductManagement;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace LenaInventoryManagementSystem.Domain
{
    public class Inventory
    {
        private static List<Product> products = new();
        internal static void MainMenu()
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

            Console.WriteLine("Selected: ");
            string? userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":
                    AddANewProduct();
                    break;
                case "2":
                    ViewAllProducts();
                    break;
                case "3":
                    UpdateAProduct();
                    break;
                case "4":
                    DeleteAProduct();
                    break;
                case "5":
                    //ViewAProduct();
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;

            }
        }

        private static void AddANewProduct()
        {

            Product? product = null;

            Console.WriteLine("How many Products do you want to add? ");
            int noOfProducts = int.Parse(Console.ReadLine());

            for (int i = 0; i < noOfProducts; i++)
            {

                Console.WriteLine($"Enter the name of the {i + 1}. product you want to add: ");
                string name = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Enter the price of the product: ");
                double price = double.Parse(Console.ReadLine() ?? "0.0");

                Console.WriteLine("Enter the quantity you want to add: ");
                int quantity = int.Parse(Console.ReadLine() ?? "0");

                //Checking if the product exists.
                Product? existingProduct = products.FirstOrDefault(p => p.ProductName == name);

                if (existingProduct != null)
                {
                    //If the product  exists, you can't add one.
                    Console.WriteLine("You can't add an existing product");
                }
                else
                {
                    //Creatng a new product if the product doesn't exists.
                    if (quantity <= 200 && quantity > 0)
                    {
                        product = new Product(name, price, quantity);
                        products.Add(product);
                        Console.WriteLine("Product added successfully.");
                    }
                    else if (quantity > 200)
                        Console.WriteLine("You can't have more than 200.");
                    else
                        Console.WriteLine("You added zero items.");
                }
            }
            MainMenu();
        }
        private static void ViewAllProducts()
        {
            //don't forget to add that if there is no products, tell the user that there is no products yet.
            foreach (Product product in products)
            {
                Console.WriteLine(product.AllDetails());
                Console.WriteLine();
            }
            MainMenu();
        }
        private static void UpdateAProduct()
        {
            Console.WriteLine("How many products do you want to update its data?");
            int noOfProducts = int.Parse(Console.ReadLine());

            for (int i = 0; i < noOfProducts; i++)
            {

                Console.WriteLine($"Enter the {i + 1}. product name that you want to update it's details: ");
                string name = Console.ReadLine() ?? string.Empty;

                Product? existingProduct = products.FirstOrDefault(p => p.ProductName == name);

                if (existingProduct != null)
                {

                    Console.WriteLine(" -------------------------------- ");
                    Console.WriteLine("| What do you want to update?    |");
                    Console.WriteLine(" -------------------------------- ");
                    Console.WriteLine("| 1: Update the product name     |");
                    Console.WriteLine("| 2: Update the product price    |");
                    Console.WriteLine("| 3: Update the product quantity |");
                    Console.WriteLine("| 4: Exit to the main menu       |");
                    Console.WriteLine(" -------------------------------- ");

                    Console.WriteLine("");
                    string? userSelection = Console.ReadLine();

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
                            Console.WriteLine("Invalid selection, please try again.");
                            break;
                    }
                }
                else
                    Console.WriteLine("Product not found. Try again.");
            }
            MainMenu();
        }
        private static void UpdateProductName()
        {
            Console.WriteLine("Please enter the product name that you want to change: ");
            string? oldName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Please enter the new name: ");
            string? newName = Console.ReadLine() ?? string.Empty;

            Product? existingProduct = products.FirstOrDefault(p => p.ProductName == oldName);

            if (existingProduct != null)
                existingProduct.ProductName = newName;
            else
                Console.WriteLine("Product not found, please try again.");

            MainMenu();

        }
        private static void UpdateProductPrice()
        {
            Console.WriteLine("Please enter the product name that you want to change its price: ");
            string? name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine($"Enter the new price of the ({name}) product: ");
            double newPrice = double.Parse(Console.ReadLine() ?? "0.0");

            Product? existingProduct = products.FirstOrDefault(p => p.ProductName == name);

            if (existingProduct != null)
                existingProduct.Price = newPrice;
            else
                Console.WriteLine("Product not found, please try again.");

            MainMenu();

        }
        private static void UpdateProductQuantity()
        {
            Console.WriteLine("Please enter the product name that you want to change its quantity: ");
            string? name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine($"Enter the new quantity of the ({name}) product: ");
            int quantity = int.Parse(Console.ReadLine() ?? "0");

            Product? existingProduct = products.FirstOrDefault(p => p.ProductName == name);

            if (existingProduct != null)
                existingProduct.Quantity = quantity;
            else
                Console.WriteLine("Product not found, please try again.");

            MainMenu();
        }
        private static void DeleteAProduct()
        {
            Console.WriteLine("How many products do you want to delete?");
            int noOfProducts = int.Parse(Console.ReadLine());

            for (int i = 0; i < noOfProducts; i++)
            {

                Console.WriteLine($"Enter the {i + 1}. product name you want to delete: ");
                string name = Console.ReadLine() ?? string.Empty;

                Product? existingProduct = products.FirstOrDefault(p => p.ProductName == name);

                if (existingProduct != null)
                {
                    products.Remove(existingProduct);
                    Console.WriteLine($"Product: {name}, was successfully deleted.");
                }
                else
                    Console.WriteLine($"Product: {name}, doesn't exist please try again.");
            }

            MainMenu();

        }


    }
}
