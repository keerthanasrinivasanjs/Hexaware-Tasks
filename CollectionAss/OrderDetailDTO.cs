using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss
{
    internal class OrderDetailDTO
    {
    
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal TotalPrice => Quantity * UnitPrice;
            public decimal UnitPrice { get; set; }

            public OrderDetailDTO(int productId, int quantity, decimal unitPrice)
            {
                ProductId = productId;
                Quantity = quantity;
                UnitPrice = unitPrice;
            }

            public override string ToString()
            {
                return $"ProductId: {ProductId}, Quantity: {Quantity}, UnitPrice: {UnitPrice:C}, TotalPrice: {TotalPrice:C}";
            }
        }

    }


