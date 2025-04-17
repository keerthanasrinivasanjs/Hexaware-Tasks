using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techshop_app
{
    public class InventoryManager
    {
        public SortedList<int, int> Inventory { get; private set; } = new();

        public void AddToInventory(Product product)
        {
            Inventory[product.Id] = product.Stock;
        }

        public void UpdateInventory(int productId, int stock)
        {
            if (Inventory.ContainsKey(productId))
                Inventory[productId] = stock;
        }

        public void ViewInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (var item in Inventory)
                Console.WriteLine($"Product ID: {item.Key}, Stock: {item.Value}");
        }
    }
}
