using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAppColby
{
    internal class InventoryItem
    {
        public string PartNumber { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Cost { get; set; }
        public decimal MyPrice { get; set; }
        public int OnHand { get; set; }
        public Uri OrderLink { get; set; }
    }
}
