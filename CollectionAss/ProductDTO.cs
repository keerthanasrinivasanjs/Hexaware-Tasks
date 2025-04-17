using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss
{
    internal class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ProductDTO(int productId, string name, decimal price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{ProductId} - {Name} - ₹{Price}";
        }
    }

}

    
