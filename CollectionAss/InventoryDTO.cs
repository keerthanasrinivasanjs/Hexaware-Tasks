using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss
{
    internal class InventoryDTO
    {
       
            public int ProductID { get; set; }
            public int QuantityInStock { get; set; }

            public InventoryDTO(int productId, int quantityInStock)
            {
                ProductID = productId;
                QuantityInStock = quantityInStock;
            }
        }
    }



