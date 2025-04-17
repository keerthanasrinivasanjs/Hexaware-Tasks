using System;
using System.Collections.Generic;

namespace CollectionAss
{
    public static class Inventory
    {
        private static SortedList<int, int> inventory = new SortedList<int, int>();

        public static void AddStock(int productId, int quantity)
        {
            if (inventory.ContainsKey(productId))
                inventory[productId] += quantity;
            else
                inventory.Add(productId, quantity);
        }

        public static void RemoveStock(int productId, int quantity)
        {
            if (inventory.ContainsKey(productId) && inventory[productId] >= quantity)
                inventory[productId] -= quantity;
        }

        public static void ViewInventory()
        {
            foreach (var kvp in inventory)
            {
                Console.WriteLine($"Product ID: {kvp.Key}, Stock: {kvp.Value}");
            }
        }
    }
}