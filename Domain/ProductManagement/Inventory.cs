using LenaInventoryManagementSystem.Domain.ProductManagement;

namespace LenaInventoryManagementSystem.Domain
{
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
                    ViewAProduct();
                    break;
                default:
                    _inventoryUI.PrintMessage("Invalid selection. Please try again.");
                    break;
            }
        }

        private static void AddANewProduct()
        {
            Product? product = null;

            var noOfProducts = int.Parse(_inventoryUI.Input("How many Products do you want to add? "));

            for (int i = 0; i < noOfProducts; i++)
            {
                var name = _inventoryUI.Input($"Enter the name of the {i + 1}. product you want to add: ");
                
                var price =double.Parse(_inventoryUI.Input("Enter the price of the product: "));

                var quantity =int.Parse(_inventoryUI.Input("Enter the quantity you want to add: "));


                //Checking if the product exists.
                Product? existingProduct = _products.FirstOrDefault(p => p.ProductName == name);

                if (existingProduct != null)
                {
                    //If the product  exists, you can't add one.
                    _inventoryUI.PrintMessage("You can't add an existing product");
                }
                else
                {
                    //Creatng a new product if the product doesn't exists.
                    if (quantity <= _maxItemsInStock && quantity > 0)
                    {
                        product = new Product(name, price, quantity);
                        _products.Add(product);
                        _inventoryUI.PrintMessage("Product added successfully.");
                    }
                    else if (quantity > _maxItemsInStock)
                        _inventoryUI.PrintMessage("You can't have more than 150.");
                    else
                        _inventoryUI.PrintMessage("You added zero items.");
                }
            }
            MainMenu();
        }

        private static void ViewAllProducts()
        {
            if (_products.Count == 0)
                _inventoryUI.PrintMessage("There is no Products in the Inventory yet.");
            else
            {
                foreach (Product product in _products)
                {
                    _inventoryUI.PrintMessage(product.AllDetails());
                    _inventoryUI.PrintMessage(" ");
                }
            }
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

        private static void UpdateProductQuantity()
        {
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
}
