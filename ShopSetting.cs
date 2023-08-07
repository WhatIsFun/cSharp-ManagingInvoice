using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_Managing_Invoices
{
    internal class ShopSetting
    {
        // Display Shop Setting Menu.
        public void ShopSettingMenu()
        {
            // Menu Display
            Console.WriteLine("Shop Setting Menu: \n1) Load Data.\n2) Set Shop Name.\n3) Set Invoice Header.\n4) Main Mune.");
            while (true)
            {
                Console.Write("\nPlease select an option: ");
                string option = Console.ReadLine();
                try
                {
                    // Check if the all inputs are numbers if not the program will loop 
                    int NoOption = int.Parse(option);
                    if (NoOption < 0 || NoOption > 5) { Console.WriteLine("Invalid input. Please enter a number between 1 and 4."); }
                    switch (NoOption)
                    {
                        case 1:
                            Console.WriteLine("Load Data");
                            ShopSettingMenu();
                            break;
                        case 2:
                            Console.WriteLine("Set Shop Name");
                            ShopSettingMenu();
                            break;
                        case 3:
                            Console.WriteLine("Set Invoice Header");
                            ShopSettingMenu();
                            break;
                        case 4:
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
    }
}
