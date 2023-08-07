using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_Managing_Invoices
{
    internal class ShopSetting
    {
        MainMenu mainMenu = new MainMenu();
        public string shopName { get; set; }
        public string invoiceHeader { get; set; } 
        public string Tel { get; set; } // shop phone number
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        


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
                            LoadData();
                            break;
                        case 2:
                            SetShopName();
                            break;
                        case 3:
                            SetInvoiceHeader();
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
        public void LoadData()
        {
            // Check if the ShopSettings folder exists
            if (Directory.Exists("ShopSettings"))
            {
                // Read each file and assign the value to the corresponding property
                if (File.Exists("ShopSettings/Shop Name.txt"))
                {
                    invoiceHeader = File.ReadAllText("ShopSettings/Shop Name.txt");
                }
                if (File.Exists("ShopSettings/Header.txt"))
                {
                    invoiceHeader = File.ReadAllText("ShopSettings/Header.txt");
                }
                if (File.Exists("ShopSettings/Tel.txt"))
                {
                    Tel = File.ReadAllText("ShopSettings/Tel.txt");
                }
                if (File.Exists("ShopSettings/Fax.txt"))
                {
                    Fax = File.ReadAllText("ShopSettings/Fax.txt");
                }
                if (File.Exists("ShopSettings/Email.txt"))
                {
                    Email = File.ReadAllText("ShopSettings/Email.txt");
                }
                if (File.Exists("ShopSettings/Website.txt"))
                {
                    Website = File.ReadAllText("ShopSettings/Website.txt");
                }
            }
            else
            {
                // Create the ShopSettings folder if it does not exist
                Directory.CreateDirectory("ShopSettings");
            }
        }

        // A method to save the shop data to files
        public void SaveData()
        {
            // Write each property value to a file in the ShopSettings folder
            File.WriteAllText("ShopSettings/Shop Name.txt", shopName);
            File.WriteAllText("ShopSettings/Header.txt", invoiceHeader);
            File.WriteAllText("ShopSettings/Tel.txt", Tel);
            File.WriteAllText("ShopSettings/Fax.txt", Fax);
            File.WriteAllText("ShopSettings/Email.txt", Email);
            File.WriteAllText("ShopSettings/Website.txt", Website);
        }

        void SetShopName()
        {
            Console.Write("What is your shop name>> ");
            string ShopName = Console.ReadLine();
            shopName = ShopName;
            SaveData();
            mainMenu.Navigation();
        }
        void SetInvoiceHeader()
        {
            Console.WriteLine("Invoice Header");
            Console.WriteLine("Enter a telephone number>");
            string telNum = Console.ReadLine();
            Console.WriteLine("Enter a shop fax>");
            string ShopFax = Console.ReadLine();
            Console.WriteLine("Enter a shop Email>");
            string email = Console.ReadLine();
            Console.WriteLine("Enter a shop website>");
            string ShopWeb = Console.ReadLine();
            Tel = telNum;
            Fax = ShopFax;
            Email = email;
            Website = ShopWeb;
            SaveData();
            mainMenu.Navigation();
        }
    }
}
