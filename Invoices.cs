using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.AcroFields;

namespace cSharp_Managing_Invoices
{
    internal class Invoice
    {
        public string InvoiceId { get; set; }
        public string CusName { get; set; } // Customer full name
        public string CusPhonNumber { get; set; } // Customer phone number
        public List<Product> Items { get; set; }
        public string InvoiceDate { get; set; }
        public static List<Invoice> invoices = new List<Invoice>();
        public float totalAmount => Items.Sum(item => item.UnitPrice * item.Quantity);
        public float paidAmount { get; set; }
        public float balance => totalAmount - paidAmount;

        public void CreateNewInvoice()
        {
            MainMenu mainMenu = new MainMenu();
            Invoice newInvoice = new Invoice();
            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy hh:mm tt");
            string formattedInvoiceId = currentDateTime.ToString("ddMMyyyyHHmmss");
            newInvoice.InvoiceDate = formattedDateTime;
            newInvoice.InvoiceId = formattedInvoiceId;
            Console.Write("Enter Customer Full Name: ");
            newInvoice.CusName = Console.ReadLine();

            Console.Write("Enter Customer Phone Number: ");
            newInvoice.CusPhonNumber = Console.ReadLine();

            int numberOfItems;
            Console.Write("Enter Number of Items: ");
            while (!int.TryParse(Console.ReadLine(), out numberOfItems) || numberOfItems <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.Write("Enter Number of Items: ");
            }
            newInvoice.Items = new List<Product>();
            for (int i = 0; i < numberOfItems; i++)
            {
                Product newItem = new Product();
                Console.WriteLine($"\nEnter details for Item {i + 1}:");
                Console.Write("Enter Item ID: ");
                newItem.ProductId = Console.ReadLine();

                Console.Write("Enter Item Name: ");
                newItem.ItemName = Console.ReadLine();

                Console.Write("Enter Unit Price: ");
                newItem.UnitPrice = float.Parse(Console.ReadLine());

                Console.Write("Enter Quantity: ");
                newItem.Quantity = Convert.ToInt32(Console.ReadLine());

                newInvoice.Items.Add(newItem);
            }
            
            Console.Write("Enter Paid Amount: ");
            decimal PaidAmount = Convert.ToDecimal(Console.ReadLine());

            invoices.Add(newInvoice);
            SaveInvoiceAsPdf(newInvoice);
            Console.WriteLine("\nInvoice created successfully.");
            mainMenu.Navigation();
        }
        static void SaveInvoiceAsPdf(Invoice invoice)
        {
            DateTime currentDateTime = DateTime.Now;
            string formattedTitle = currentDateTime.ToString("ddMMyyyyHHmmss");
            string pdfFileName = $"Invoices/Invoice_{formattedTitle}.pdf";

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFileName, FileMode.Create));

            document.Open();

            document.Add(new Paragraph("Invoice"));

            //Invoice details
            document.Add(new Paragraph($"Invoice Number: {invoice.InvoiceId}"));
            document.Add(new Paragraph($"Customer: {invoice.CusName}"));
            document.Add(new Paragraph($"Phone Number: {invoice.CusPhonNumber}"));
            document.Add(new Paragraph($"Invoice Date: {invoice.InvoiceDate}"));

            //Item details
            PdfPTable table = new PdfPTable(4);
            table.AddCell("Item ID");
            table.AddCell("Item Name");
            table.AddCell("Unit Price");
            table.AddCell("Quantity");

            foreach (var item in invoice.Items)
            {
                table.AddCell(item.ProductId.ToString());
                table.AddCell(item.ItemName);
                table.AddCell(item.UnitPrice.ToString());
                table.AddCell(item.Quantity.ToString());
            }

            document.Add(table);

            document.Add(new Paragraph($"Total Amount: {invoice.totalAmount:C}"));
            document.Add(new Paragraph($"Paid Amount: {invoice.paidAmount:C}"));
            document.Add(new Paragraph($"Balance: {invoice.balance:C}"));

            document.Close();

            Console.WriteLine($"Invoice saved as {pdfFileName}");
        }

    }
}

