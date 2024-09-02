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
                   // UpdateAProduct();
                    break;
                case "4":
                    //DeleteAProduct();
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

    }
}
