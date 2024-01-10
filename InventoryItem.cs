using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAppColby
{
    public class InventoryItem
    {
        public string PartNumber { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal OnHand { get; set; }
        public Uri Order { get; set; }
        public decimal QuantityUsed { get; set; }
        public decimal OriginalOnHand { get; set; }
        public decimal Total { get; set; }

        public string CustomerName { get; set; }
        public string ContactInfo { get; set; }

    }
}
