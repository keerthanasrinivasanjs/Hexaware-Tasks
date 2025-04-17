using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAss;

namespace techshop_app
{
    internal class OrderManager
    {
       
        
            private List<Order> orders = new List<Order>();

            public void PlaceOrder(Product product, int quantity)
            {
                if (product.Stock < quantity) throw new Exception("Insufficient stock.");

                product.Stock -= quantity;
                Inventory.AddStock(product.Id, -quantity);

                int orderId = orders.Count + 1;
                Order order = new Order
                {
                    Id = orderId,
                    Product = product,
                    Quantity = quantity,
                    Status = "Processing",
                    OrderDate = DateTime.Now
                };

                orders.Add(order);
                Console.WriteLine("Order placed successfully.");
            }

            public void CancelOrder(int id)
            {
                Order order = orders.FirstOrDefault(o => o.Id == id);
                if (order == null) throw new Exception("Order not found.");

                order.Product.Stock += order.Quantity;
                Inventory.AddStock(order.Product.Id, order.Quantity);
                order.Status = "Cancelled";
                Console.WriteLine("Order cancelled.");
            }

            public void UpdateOrderStatus(int id, string status)
            {
                Order order = orders.FirstOrDefault(o => o.Id == id);
                if (order != null)
                {
                    order.Status = status;
                    Console.WriteLine("Order status updated.");
                }
                else
                {
                    Console.WriteLine("Order not found.");
                }
            }

            public List<Order> GetAllOrders()
            {
                return orders;
            }

            public List<Order> GetSortedOrdersByDate()
            {
                return orders.OrderBy(o => o.OrderDate).ToList();
            }
        }
    }