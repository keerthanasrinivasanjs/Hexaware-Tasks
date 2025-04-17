using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlling
{
    internal class InventoryManager
    {
        private Dictionary<string, int> stock;

        public InventoryManager(Dictionary<string, int> stock)
        {
            this.stock = stock;
        }

        public void ProcessOrder(string productId, int orderedQuantity)
        {
            if (orderedQuantity > GetAvailableStock(productId))
            {
                throw new InsufficientStockException("Cannot fulfill order due to insufficient stock.");
            }
        }

        public int GetAvailableStock(string productId)
        {
            return stock.ContainsKey(productId) ? stock[productId] : 0;
        }
    }
}

