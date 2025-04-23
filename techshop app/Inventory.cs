using System;
using System.Collections.Generic;
using CollectionAss;
using techshopapp;

namespace CollectionAss
{
    class Inventory
    {
        private static int idCounter = 1;
        private int inventoryID;
        private Product product;
        private int quantityInStock;
        private DateTime lastStockUpdate;

        public int InventoryID => inventoryID;
        public Product Product => product;
        public int QuantityInStock => quantityInStock;
        public DateTime LastStockUpdate => lastStockUpdate;

        public Inventory(Product p, int qty)
        {
            inventoryID = idCounter++;
            product = p;
            quantityInStock = qty;
            lastStockUpdate = DateTime.Now;
        }
    }
}
