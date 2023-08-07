using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_Managing_Invoices
{
    internal class ManageShopItem
    {
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
                            MainMenu mainMenu = new MainMenu();
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
            //Product newItem = new Product();

            //Console.Write("Enter the Item ID: ");
            //newItem.ProductId = Console.ReadLine();

            //Console.Write("Enter the Item Name: ");
            //newItem.Name = Console.ReadLine();

            //Console.Write("Enter the Unit Price: ");
            //newItem.UnitPrice = Convert.ToDecimal(Console.ReadLine());

            //Console.Write("Enter the Quantity: ");
            //newItem.Quantity = Convert.ToInt32(Console.ReadLine);

            //shopItems.Add(newItem);
            //Console.WriteLine("Item added successfully.");
        }
        void RemoveItem()
        {
            //Console.Write("Enter the Item ID to delete: ");
            //string itemIdToDelete = Console.ReadLine();

            //Item itemToRemove = shopItems.FirstOrDefault(item => item.ItemId == itemIdToDelete);

            //if (itemToRemove != null)
            //{
            //    shopItems.Remove(itemToRemove);
            //    Console.WriteLine("Item deleted successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Item not found.");
            //}
        }
        void ChangePrice()
        {

        }
        void DisplayItems()
        {

        }
    }
}
