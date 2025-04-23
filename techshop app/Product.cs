using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAss;

namespace techshopapp
{
    class Product
    {
        private static int idCounter = 1;
        private int productID;
        private string productName, description;
        private decimal price;

        public int ProductID => productID;
        public string ProductName { get => productName; set => productName = value; }
        public string Description { get => description; set => description = value; }
        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0) throw new ArgumentException("Price cannot be negative.");
                price = value;
            }
        }

        public Product(string name, string desc, decimal pr)
        {
            productID = idCounter++;
            ProductName = name;
            Description = desc;
            Price = pr;
        }
    }
}