using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_Managing_Invoices
{
    internal class ManageShopItem
    {
        public static List<Product> shopItems = new List<Product>();
        MainMenu mainMenu = new MainMenu();
        // Display Manage Shop Items Menu.
        public void ManageShopMenu()
        {
            // Menu Display
            Console.WriteLine("Manage Shop Items Menu: \n1) Add Items.\n2) Delete Items by ID.\n3) Change Item price by ID.\n4) Report All Items.\n5) Main Mune.");
            while (true)
            {
                Console.Write("\nPlease select an option: ");
                string option = Console.ReadLine();
                try
                {
                    // Check if the all inputs are numbers if not the program will loop 
                    int NoOption = int.Parse(option);
                    if (NoOption < 0 || NoOption > 6) { Console.WriteLine("Invalid input. Please enter a number between 1 and 5."); }
                    switch (NoOption)
                    {
                        case 1:
                            AddItem();
                            break;
                        case 2:
                            RemoveItem();
                            break;
                        case 3:
                            ChangePrice();
                            break;
                        case 4:
                            DisplayItems();
                            break;
                        case 5:
                            mainMenu.Menu();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
        void AddItem()
        {
            Product newItem = new Product();

            Console.Write("Enter the product ID: ");
            newItem.ProductId = Console.ReadLine();

            Console.Write("Enter the product name: ");
            newItem.ItemName = Console.ReadLine();

            Console.Write("Enter the product unit price: ");
            newItem.UnitPrice = float.Parse(Console.ReadLine());

            Console.Write("Enter product quantity: ");
            newItem.Quantity = int.Parse(Console.ReadLine());


            shopItems.Add(newItem);
            Console.WriteLine("Item added successfully.");
            mainMenu.Navigation();

        }
        void RemoveItem()
        {
            Console.Write("Enter the Item ID to delete: ");
            string productIdToDelete = Console.ReadLine();

            Product itemToRemove = shopItems.FirstOrDefault(item => item.ProductId == productIdToDelete);

            if (itemToRemove != null)
            {
                shopItems.Remove(itemToRemove);
                Console.WriteLine("Item deleted successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
            mainMenu.Navigation();
        }
        void ChangePrice()
        {
            Console.Write("Enter the Item ID to change the price: ");
            string productIdToChangePrice = Console.ReadLine();

            Product itemToChangePrice = shopItems.FirstOrDefault(item => item.ProductId == productIdToChangePrice);

            if (itemToChangePrice != null)
            {
                Console.Write("Enter the new Unit Price: ");
                itemToChangePrice.UnitPrice = float.Parse(Console.ReadLine());
                Console.WriteLine("Item price changed successfully to {0} OMR.", productIdToChangePrice);
                
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
            mainMenu.Navigation();
        }
        void DisplayItems()
        {
            if (shopItems.Count == 0)
            {
                Console.WriteLine("No items found in the shop.");
            }
            else
            {
                Console.WriteLine("\nAll Shop Items:");
                foreach (Product item in shopItems)
                {
                    Console.WriteLine($"Item ID: {item.ProductId}, Item Name: {item.ItemName}, Unit Price: {item.UnitPrice}, Quantity: {item.Quantity}");
                }
            }
            mainMenu.Navigation();
        }
    }
}
