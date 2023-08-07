using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_Managing_Invoices
{
    internal class ManageShopItem
    {
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
                            Console.WriteLine("1");
                            ManageShopMenu();
                            break;
                        case 2:
                            Console.WriteLine("2");
                            ManageShopMenu();
                            break;
                        case 3:
                            Console.WriteLine("3");
                            ManageShopMenu();
                            break;
                        case 4:
                            Console.WriteLine("4");
                            ManageShopMenu();
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
        //void AddItem()
        //{
            
        //}
        //void RemoveItem()
        //{

        //}
        //void ChangePrice()
        //{

        //}
        //void DisplayItems()
        //{

        //}
    }
}
