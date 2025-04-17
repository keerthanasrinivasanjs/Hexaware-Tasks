using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techshop_app
{
    internal class Customer
    {
        
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }

            public void ViewOrders(List<Order> orders)
            {
                var customerOrders = orders.Where(o => o.Product.Id == Id).ToList();
                foreach (var order in customerOrders)
                {
                    Console.WriteLine($"Order ID: {order.Id}, Product: {order.Product.Name}, Status: {order.Status}");
                }
            }
        }
    }
