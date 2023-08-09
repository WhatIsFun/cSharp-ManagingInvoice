using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.AcroFields;

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
        public List<Product> shopItems = new List<Product>();
        public  List<Invoice> Invoices = new List<Invoice>();
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
            LoadItems(ref shopItems);
            LoadInvoices(ref Invoices);
            LoadInvoiceHeader();
        }
        static void LoadInvoiceHeader()
        {
            try
            {
                if (File.Exists("Shop Setting/InvoiceHeader.txt"))
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
                else
                {
                    Directory.CreateDirectory("Shop Setting");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }
        public void LoadItems(ref List<Product> shopItems)
        {
            try
            {
                if (Directory.Exists("Shop Setting/Items"))
                {
                    if (File.Exists("Shop Setting/Items/items.json"))
                    {
                        string json = File.ReadAllText("Shop Setting/Items/items.json");
                        shopItems = JsonSerializer.Deserialize<List<Product>>(json);
                    }
                    else
                    {
                        shopItems = new List<Product>();
                    }
                }
                else
                {
                    Directory.CreateDirectory("Shop Setting/Items");
                    shopItems = new List<Product>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading items data: {ex.Message}");
                shopItems = new List<Product>(); 
            }

        }

        public void LoadInvoices(ref List<Invoice> Invoices)
        {
            try
            {
                if (Directory.Exists("Shop Setting/Invoices"))
                {
                    if (File.Exists("Shop Setting/Invoices/invoices.json"))
                    {
                        string json = File.ReadAllText("Shop Setting/Invoices/invoices.json");
                        Invoices = JsonSerializer.Deserialize<List<Invoice>>(json);
                    }
                    else
                    {
                        Invoices = new List<Invoice>();
                    }
                }
                else
                {
                    Directory.CreateDirectory("Shop Setting/Invoices");
                    Invoices = new List<Invoice>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading invoices data: {ex.Message}");
                Invoices = new List<Invoice>();
            }


        }
        public void SaveInvoiceHeaderData(string shopTel, string shopFax, string shopEmail, string shopWebsite)
        {
            using (StreamWriter writer = new StreamWriter("Shop Setting/InvoiceHeader.txt"))
            {
                writer.WriteLine(shopTel);
                writer.WriteLine(shopFax);
                writer.WriteLine(shopEmail);
                writer.WriteLine(shopWebsite);
            }
        }
        public void SetInvoiceHeader()
        {
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
            ShopSetting shopSetting = new ShopSetting();
            shopSetting.ShopSettingMenu();
        }
        public void SetShopName()
        {
            Console.Write("Enter the new shop name: ");
            string shopName = Console.ReadLine();
            Console.WriteLine("Shop name set successfully.");
            SaveShopNameData(shopName);
            ShopSetting shopSetting = new ShopSetting();
            shopSetting.ShopSettingMenu();
        }
        public void SaveShopNameData(string shopName)
        {
            using (StreamWriter writer = new StreamWriter("ShopName.txt"))
            {
                writer.WriteLine(shopName);
            }
        }
        public void SaveData()
        {
            SaveItems(shopItems);
            SaveInvoices(Invoices);
        }
        public void SaveItems(List <Product> shopItems)
        {
            try
            {
                string json = JsonSerializer.Serialize(shopItems, new JsonSerializerOptions { WriteIndented = true });
                Directory.CreateDirectory("Shop Setting/Items"); // Create directory if it doesn't exist
                File.WriteAllText("Shop Setting/Items/items.json", json);
                Console.WriteLine("Items saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving items: {ex.Message}");
            }
        }
        public void SaveInvoices(List<Invoice> Invoices)
        {
            try
            {
                string json = JsonSerializer.Serialize(Invoices, new JsonSerializerOptions { WriteIndented = true });
                Directory.CreateDirectory("Shop Setting/Invoices"); 
                File.WriteAllText("Shop Setting/Invoices/invoices.json", json);
                Console.WriteLine("Invoices saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving invoices: {ex.Message}");
            }
        }
    }
}
