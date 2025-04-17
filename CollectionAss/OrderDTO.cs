using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss
{
    internal class OrderDTO
    {
     
            public int OrderId { get; set; }
            public DateTime OrderDate { get; set; }
            public string Status { get; set; }

            public OrderDTO(int orderId, DateTime orderDate, string status)
            {
                OrderId = orderId;
                OrderDate = orderDate;
                Status = status;
            }

            public override string ToString()
            {
                return $"OrderId: {OrderId}, Date: {OrderDate.ToShortDateString()}, Status: {Status}";
            }
        }

    }



