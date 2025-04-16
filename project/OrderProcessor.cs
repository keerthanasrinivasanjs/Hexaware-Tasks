using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlling
{
    internal class OrderProcessor
    {
        public void ProcessOrder(Dictionary<string, object> orderDetails)
        {
            if (!orderDetails.ContainsKey("product_reference"))
            {
                throw new IncompleteOrderException("Order is incomplete: missing product reference.");
            }
        }
    }
}

