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
        public float Total => Items.Sum(item => item.UnitPrice * item.Quantity);
        public float PaidAmount { get; set; }
        public float Balance => Total - PaidAmount;
    }
}

