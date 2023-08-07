using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_Managing_Invoices
{
    internal class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        //public Product(string Name, decimal UnitPrice, int Quantity, string ProductId, string Description)
        //{

        //}
    }
}
