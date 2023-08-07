using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cSharp_Managing_Invoices
{
    internal class MainMenu
    {
        public void Menu()
        {
            int shopSettingCount = 0;
            int manageItemCount = 0;
            int newInvoiceCount = 0;
            int reportStatCount = 0;
            int reportAllInvoiceCount = 0;
            int programStatCount =0;
            int exitCount =0;
            // Menu Display
            Console.WriteLine("Main Menu: \n1) Shop Settings.\n2) Manage Shop Items.\n3) Create New Invoice.\n4) Report Statistics.\n5) Report All Invoices.\n6) Search for Invoices.\n7) Program Statistics.\n8) Exit.");
            while (true)
            {
                Console.Write("\nPlease select an option: ");
                string option = Console.ReadLine();
                try
                {
                    // Check if the all inputs are numbers if not the program will loop 
                    int NoOption = int.Parse(option);
                    if (NoOption < 0 || NoOption > 9) { Console.WriteLine("Invalid input. Please enter a number between 1 and 8."); }
                    switch (NoOption)
                    {
                        case 1:
                            ShopSetting shopSetting = new ShopSetting();
                            shopSetting.ShopSettingMenu();
                            shopSettingCount++;
                            break;
                        case 2:
                            ManageShopItem manageShopItem = new ManageShopItem();
                            manageShopItem.ManageShopMenu();
                            manageItemCount++;
                            break;
                        case 3:
                            Console.WriteLine("3");
                            break;
                        case 4:
                            Console.WriteLine("4");
                            break;
                        case 5:
                            Console.WriteLine("5");
                            break;
                        case 6:
                            Console.WriteLine("6");
                            break;
                        case 7:
                            Console.WriteLine("7");
                            break;
                        case 8:
                            Console.Write("Are you sure you want to exit? (y/n)"); // Check if the user want to exit the application
                            string ExitInput = Console.ReadLine();
                            if (ExitInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Write("Thank You");
                                Environment.Exit(0);
                            }
                            else
                            {
                                Menu();
                            } 
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
        public void Navigation()
        {
            while (true)
            {
                Console.Write("Press (1) to go back, And (2) to Main Menu.\nIf you to exit press (3): ");
                string option = Console.ReadLine();
                try
                {
                    // Check if the all inputs are numbers if not the program will loop 
                    int NoOption = int.Parse(option);
                    if (NoOption < 0 || NoOption > 4) { Console.WriteLine("Invalid input. Please enter a number between 1 and 3."); }
                    switch (NoOption)
                    {
                        case 1:
                            ShopSetting shopSetting = new ShopSetting();
                            shopSetting.ShopSettingMenu();
                            break;
                        case 2:
                            Menu();
                            break;
                        case 3:
                            Console.Write("Are you sure you want to exit? (y/n)"); // Check if the user want to exit the application
                            string ExitInput = Console.ReadLine();
                            if (ExitInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Write("Thank You");
                                Environment.Exit(0);
                            }
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}
