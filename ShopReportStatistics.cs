using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.AcroFields;

namespace cSharp_Managing_Invoices
{
    internal class ShopReportStatistics
    {
        private static int[] mainMenuSelections = new int[8];
        public void ReportStatistics()
        {
            ShopSetting shopSetting = new ShopSetting();
            shopSetting.LoadData();
            int numberOfItems = shopSetting.shopItems.Count;
            int numberOfInvoices = shopSetting.Invoices.Count;
            double totalSales = shopSetting.Invoices.Sum(Invoices => Invoices.Total);

            Console.WriteLine($"{shopSetting.shopName} Statistics");
            Console.WriteLine("Number of avaliable item in the shop: {0}\nNumber of Invoices: {1}\nTotal Sales: {2} OMR", numberOfItems,numberOfInvoices, totalSales);
        }
        public void ReportAllInvoices() 
        {
            ShopSetting shopSetting = new ShopSetting();
            shopSetting.LoadData();
            Console.WriteLine("',`',` Report All Invoices ',`',`");
            foreach(Invoice invoice in shopSetting.Invoices)
            {
                Console.WriteLine($"Invoice Number:          {invoice.InvoiceId}");
                Console.WriteLine($"Invoice Date and Time:   {invoice.InvoiceDate}");
                Console.WriteLine($"Customer Name:           {invoice.CusName}");
                Console.WriteLine($"Number of Items:         {invoice.Items.Count}");
                Console.WriteLine($"Total Amount:            {invoice.Total} OMR");
                Console.WriteLine($"Balance:                 {invoice.Balance} OMR");
                Console.WriteLine("__________________________________________________");
            }
        }
        public void InvoiceSearching()
        {
            ShopSetting shopSetting = new ShopSetting();
            shopSetting.LoadData();
            Console.WriteLine("Search for Invoice By ID:\n\n\n");
            Console.WriteLine("Enter the Invoice Id: ");
            string inputInvoiceId = Console.ReadLine();
            var InvoiceSearsh = shopSetting.Invoices.Find(x => x.InvoiceId == inputInvoiceId);
            if (InvoiceSearsh != null)
            {
                Console.WriteLine($"Invoice Number: {InvoiceSearsh.InvoiceId} \nInvoice Date and Time: {InvoiceSearsh.InvoiceDate} \nCustomer Name: {InvoiceSearsh.CusName}\nNumber Of Items: {InvoiceSearsh.Items.Count}\nTotal Amount: {InvoiceSearsh.Total} OMR\nPaid Amound: {InvoiceSearsh.PaidAmount} OMR\nBalance: {InvoiceSearsh.Balance} OMR");
                Console.WriteLine("Items in this invoice as below: ");
                foreach (var items in InvoiceSearsh.Items)
                {
                    Console.WriteLine($"Item Id: {items.ProductId} \nName: {items.ItemName}\nUnit Price: {items.UnitPrice}\nQuantity: {items.Quantity}");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid Invoice ID.." +
                    "Thank you");
            }
        }
        public void trackProgramStatistics(int menuItem)
        {
            if (menuItem >= 1 && menuItem <= 8)
            {
                mainMenuSelections[menuItem - 1]++;
            }
        }
        public void ProgramStatistics()
        {
            Console.WriteLine("~~~ ~~ ~ Program Statistics ~ ~~ ~~~");
            for (int i = 0; i < mainMenuSelections.Length; i++)
            {
                Console.WriteLine($"Menu Option {i + 1}: Selected {mainMenuSelections[i]} times.");
            }
        }
    }
}
