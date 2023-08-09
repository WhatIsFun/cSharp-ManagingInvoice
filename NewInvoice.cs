using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_Managing_Invoices
{
    internal class NewInvoice
    {
        public void CreateNewInvoice(List<Product> shopItems)
        {
            MainMenu mainMenu = new MainMenu();
            Invoice newInvoice = new Invoice();
            ShopSetting shopSetting = new ShopSetting();
            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy hh:mm tt");
            string formattedInvoiceId = currentDateTime.ToString("ddMMyyyyHHmmss");
            newInvoice.InvoiceDate = formattedDateTime;
            newInvoice.InvoiceId = formattedInvoiceId;
            Console.Write("Enter Customer Full Name: ");
            newInvoice.CusName = Console.ReadLine();

            Console.Write("Enter Customer Phone Number: ");
            newInvoice.CusPhonNumber = Console.ReadLine();
            newInvoice.Items = new List<Product>();
            Product newItem = new Product();
            string searchId = "";

            while (searchId != "0")
            {
                Console.Write("Enter a Product ID (Enter 0 to exit): ");
                searchId = Console.ReadLine();

                if (searchId == "0")
                {
                    break;
                }

                Product foundProduct = shopItems.Find(x => x.ProductId == searchId);

                if (foundProduct != null)
                {
                    Console.WriteLine($"Name: {foundProduct.ItemName}\nUnit Price: {foundProduct.UnitPrice} OMR");
                    Console.Write("Enter Quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    newInvoice.Items.Add(new Product
                    {
                        ProductId = foundProduct.ProductId,
                        ItemName = foundProduct.ItemName,
                        UnitPrice = foundProduct.UnitPrice,
                        Quantity = quantity
                    });
                }
                else
                {
                    Console.WriteLine("Product not found...");
                }
            }


            Console.WriteLine($"Total: {CalculateTotal(newInvoice.Items)} OMR");
            Console.Write("Enter Paid Amount: ");
            float PaidAmount = float.Parse(Console.ReadLine());

            Console.WriteLine($"Balance: {newInvoice.Balance} OMR");

            shopSetting.Invoices.Add(newInvoice);

            // Save the invoice as PDF
            SaveInvoiceAsPdf(newInvoice);

            Console.WriteLine("\nInvoice created successfully.");
            mainMenu.Menu();
        }
        private float CalculateTotal(List<Product> items)
        {
            float total = 0;
            foreach (var item in items)
            {
                total += item.UnitPrice * item.Quantity;
            }
            return total;
        }
        static void SaveInvoiceAsPdf(Invoice Invoice)
        {
            ShopSetting shopSetting = new ShopSetting();
            DateTime currentDateTime = DateTime.Now;
            string formattedTitle = currentDateTime.ToString("ddMMyyyyHHmmss");
            string pdfFileName = $"Invoices/Invoice_{formattedTitle}.pdf";

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFileName, FileMode.Create));

            document.Open();

            document.Add(new Paragraph("Invoice"));

            //Invoice details
            document.Add(new Paragraph($"Invoice Number: {Invoice.InvoiceId}"));
            document.Add(new Paragraph($"Customer: {Invoice.CusName}"));
            document.Add(new Paragraph($"Phone Number: {Invoice.CusPhonNumber}"));
            document.Add(new Paragraph($"Invoice Date: {Invoice.InvoiceDate}"));

            //Item details
            PdfPTable table = new PdfPTable(4);
            table.AddCell("Item ID");
            table.AddCell("Item Name");
            table.AddCell("Unit Price");
            table.AddCell("Quantity");

            foreach (var item in Invoice.Items)
            {
                table.AddCell(item.ProductId.ToString());
                table.AddCell(item.ItemName);
                table.AddCell(item.UnitPrice.ToString());
                table.AddCell(item.Quantity.ToString());
            }

            document.Add(table);

            document.Add(new Paragraph($"Total Amount: {Invoice.Total} OMR"));
            document.Add(new Paragraph($"Paid Amount: {Invoice.PaidAmount} OMR"));
            document.Add(new Paragraph($"Balance: {Invoice.Balance} OMR"));

            document.Close();

            Console.WriteLine($"Invoice saved as {pdfFileName}");
        }
    }
}
