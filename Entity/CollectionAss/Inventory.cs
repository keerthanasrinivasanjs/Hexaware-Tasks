using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss
{
    internal class Inventory
    {
      
            public int ProductID { get; set; }
            public int QuantityInStock { get; set; }

            public Inventory(int productId, int quantityInStock)
            {
                ProductID = productId;
                QuantityInStock = quantityInStock;
            }

            public override string ToString()
            {
                return $"ProductID: {ProductID}, QuantityInStock: {QuantityInStock}";
            }
        }
    }



