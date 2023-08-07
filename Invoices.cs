using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_Managing_Invoices
{
    internal class Invoice
    {
        DateTime currentDateTime = DateTime.Now;
        //string formattedDateTime = currentDateTime.ToString("dd MMMM yyyy HH:mm:ss tt");
        //Console.WriteLine("Current date and time: " + formattedDateTime);

        public int invoiceId { get; set; }
        public string CusName { get; set; } // Customer full name
        public string CusPhonNumber { get; set; } // Customer phone number

        public decimal totalAmount { get; set; }
        public decimal paidAmount { get; set; }
        public decimal balance { get; set; }

        
        public void NewInvoice()
        {
            string formattedDateTime = currentDateTime.ToString("dd MMMM yyyy HH:mm:ss tt");
            
        }
    }
}
