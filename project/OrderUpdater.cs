using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlling
{
    internal class OrderUpdater
    {
        public void UpdateOrder(string orderId, object newData)
        {
            if (CheckOrderConflict(orderId))
            {
                throw new ConcurrencyException("This order has been modified by another user. Please retry.");
            }

            
        }

        private bool CheckOrderConflict(string orderId)
        {
           
            return false; 
        }
    }
}

