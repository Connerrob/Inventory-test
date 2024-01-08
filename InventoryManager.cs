using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAppColby
{
    public class InventoryManager
    {
        private List<InventoryItem> inventoryItems;

       
        public InventoryManager(List<InventoryItem> initialInventory)
        {
            inventoryItems = initialInventory;
        }

        public void UpdateInventory(List<InventoryItem> selectedItems)
        {
            foreach (var selectedItem in selectedItems)
            {
                // Find the corresponding item in the inventory
                InventoryItem inventoryItem = inventoryItems.FirstOrDefault(item => item.PartNumber == selectedItem.PartNumber);

                if (inventoryItem != null)
                {
                    // Decrement OnHand by 1
                    inventoryItem.OnHand -= 1;
                }
            }
        }
    }
}