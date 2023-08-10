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
            ShopReportStatistics shopReportStatistics = new ShopReportStatistics();
            ShopSetting shopSetting = new ShopSetting();

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
                    shopReportStatistics.trackProgramStatistics(NoOption);
                    switch (NoOption)
                    {
                        case 1:
                            //ShopSetting shopSetting = new ShopSetting();
                            shopSetting.ShopSettingMenu();
                            break;
                        case 2:
                            ManageShopItem manageShopItem = new ManageShopItem();
                            manageShopItem.ManageShopMenu();
                            break;
                        case 3:
                            NewInvoice invoiceSystem = new NewInvoice();
                            invoiceSystem.CreateNewInvoice();
                            break;
                        case 4:
                            shopReportStatistics.ReportStatistics();
                            break;
                        case 5:
                            shopReportStatistics.ReportAllInvoices();
                            break;
                        case 6:
                            shopReportStatistics.InvoiceSearching();
                            break;
                        case 7:
                            shopReportStatistics.ProgramStatistics();
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
    }
}
