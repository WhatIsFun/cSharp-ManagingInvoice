using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_Managing_Invoices
{
    internal class ShopSetting
    {
        public string shopName { get; set; }
        public string invoiceHeader { get; set; } 
        public string Tel { get; set; } // shop phone number
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public List<Product> Items { get; set; }
        public List<Invoice> Invoices { get; set; }
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
        static void LoadData()
        {
            MainMenu mainMenu = new MainMenu();

            if (Directory.Exists("Items"))
            {
                if (File.Exists("Items/items.bin"))
                {
                    using (Stream stream = File.Open("Items/items.bin", FileMode.Open))
                    {
                        var formatter1 = new BinaryFormatter();
                        var shopItems = (List<Product>)formatter1.Deserialize(stream);
                    }
                }
                else
                {
                    var shopItems = new List<Product>();
                }
            }
            else
            {
                Directory.CreateDirectory("Items");
                var shopItems = new List<Product>();
                using (Stream stream = File.Open("Items/items.bin", FileMode.Create)) // check if it works
                {
                    var formatter = new BinaryFormatter();
                    //formatter.Serialize(stream, shopItems);
                }
            }
            if (Directory.Exists("Invoices"))
            {
                if (File.Exists("Invoices/Invoice.bin"))
                {
                    using (Stream stream = File.Open("Invoices/Invoice.bin", FileMode.Open))
                    {
                        var formatter2 = new BinaryFormatter();
                        var shopInvoice = (List<Invoice>)formatter2.Deserialize(stream);
                    }
                }
                else
                {
                    var shopInvoice = new List<Invoice>();
                }
            }
            else
            {
                Directory.CreateDirectory("Invoices");
                var shopInvoice = new List<Invoice>();
            }

            if (File.Exists("InvoiceHeader.txt"))
            {
                using (StreamReader reader = new StreamReader("InvoiceHeader.txt"))
                {
                    string invoiceHeader = reader.ReadToEnd();
                    string[] headerParts = invoiceHeader.Split('\n');
                    if (headerParts.Length == 4)
                    {
                        string Tel = headerParts[0].Trim();
                        string Fax = headerParts[1].Trim();
                        string Email = headerParts[2].Trim();
                        string Website = headerParts[3].Trim();
                    }
                }
            }
            mainMenu.Navigation();
        }
        static void SaveInvoiceHeaderData(string shopTel, string shopFax, string shopEmail, string shopWebsite)
        {
            using (StreamWriter writer = new StreamWriter("InvoiceHeader.txt"))
            {
                writer.WriteLine(shopTel);
                writer.WriteLine(shopFax);
                writer.WriteLine(shopEmail);
                writer.WriteLine(shopWebsite);
            }
        }
        static void SetInvoiceHeader()
        {
            MainMenu mainMenu = new MainMenu();

            Console.Write("Enter the shop telephone number: ");
            string shopTel = Console.ReadLine();

            Console.Write("Enter the shop fax number: ");
            string shopFax = Console.ReadLine();

            Console.Write("Enter the shop email: ");
            string shopEmail = Console.ReadLine();

            Console.Write("Enter the shop website: ");
            string shopWebsite = Console.ReadLine();

            Console.WriteLine("Invoice header set successfully.");
            SaveInvoiceHeaderData(shopTel, shopFax, shopEmail, shopWebsite);
            mainMenu.Navigation();
        }
        static void SetShopName()
        {
            MainMenu mainMenu = new MainMenu();

            Console.Write("Enter the new shop name: ");
            string shopName = Console.ReadLine();
            Console.WriteLine("Shop name set successfully.");
            SaveShopNameData(shopName);
            mainMenu.Navigation();
        }
        static void SaveShopNameData(string shopName)
        {
            using (StreamWriter writer = new StreamWriter("ShopName.txt"))
            {
                writer.WriteLine(shopName);
            }
        }


        
    }
}
