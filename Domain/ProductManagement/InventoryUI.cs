namespace LenaInventoryManagementSystem.Domain.ProductManagement
{
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
}
