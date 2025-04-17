using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss
{
    internal class OrderDetail
    {
      
            public int OrderDetailId { get; set; }
            public int OrderId { get; set; }  
            public int ProductId { get; set; }  
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }

            public OrderDetail(int orderDetailId, int orderId, int productId, int quantity, decimal unitPrice)
            {
                OrderDetailId = orderDetailId;
                OrderId = orderId;
                ProductId = productId;
                Quantity = quantity;
                UnitPrice = unitPrice;
            }

            public override string ToString()
            {
                return $"OrderDetailId: {OrderDetailId}, OrderId: {OrderId}, ProductId: {ProductId}, Quantity: {Quantity}, UnitPrice: {UnitPrice:C}";
            }
        }

    }


