using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss
{
    internal class OrderSortService
    {
      
            private List<Order> orders;

            public OrderSortService(List<Order> orderList)
            {
                orders = orderList;
            }

            public List<Order> SortByOrderDate(bool ascending = true)
            {
                return ascending
                    ? orders.OrderBy(o => o.OrderDate).ToList()
                    : orders.OrderByDescending(o => o.OrderDate).ToList();
            }

            public List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
            {
                return orders
                    .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                    .OrderBy(o => o.OrderDate)
                    .ToList();
            }
        }
    }




