using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss
{
    internal class Product

    {

        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

    
        public Product(int productId, string sku, string name, decimal price)
        {
            ProductId = productId;
            SKU = sku ?? throw new ArgumentNullException(nameof(sku), "SKU cannot be null.");
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null.");
            Price = price;
        }

       
        public Product(int productId, string sku, string name, decimal price, string category, string description)
            : this(productId, sku, name, price)
        {
            Category = category;
            Description = description;
        }

        public override string ToString()
        {
            return $"[{ProductId}] {Name} - {Category} - ₹{Price} (SKU: {SKU})";
        }
    }
}