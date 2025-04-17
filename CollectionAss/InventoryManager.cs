using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss
{
    internal class InventoryManager
    {
       
        private SortedList<int, Inventory> inventoryList;

            public InventoryManager()
            {
                inventoryList = new SortedList<int, Inventory>();
            }

          
            public void AddInventory(Inventory inventory)
            {
                if (inventoryList.ContainsKey(inventory.ProductID))
                {
                    throw new Exception("Inventory for this product already exists.");
                }
                inventoryList.Add(inventory.ProductID, inventory);
            }

          
            public void UpdateInventory(int productId, int newQuantity)
            {
                if (inventoryList.ContainsKey(productId))
                {
                    inventoryList[productId].QuantityInStock = newQuantity;
                }
                else
                {
                    throw new Exception("Product not found in inventory.");
                }
            }

       
            public void ReduceStock(int productId, int quantity)
            {
                if (!inventoryList.ContainsKey(productId))
                {
                    throw new Exception("Product not found in inventory.");
                }

                Inventory inv = inventoryList[productId];
                if (inv.QuantityInStock < quantity)
                {
                    throw new Exception("Insufficient stock available.");
                }

                inv.QuantityInStock -= quantity;
            }

            public Inventory GetInventory(int productId)
            {
                if (inventoryList.ContainsKey(productId))
                {
                    return inventoryList[productId];
                }
                else
                {
                    throw new Exception("Product not found in inventory.");
                }
            }

     
            public void DisplayInventory()
            {
                foreach (var item in inventoryList)
                {
                    Console.WriteLine(item.Value.ToString());
                }
            }
        }
    }



