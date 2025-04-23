using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techshopapp;

namespace techshopapp
{
    class Order
    {
        private static int idCounter = 1;
        private int orderID;
        private Customer customer;
        private DateTime orderDate;
        private List<OrderDetail> orderDetails = new List<OrderDetail>();

        public int OrderID => orderID;
        public Customer Customer => customer;
        public DateTime OrderDate => orderDate;

        public Order(Customer c)
        {
            orderID = idCounter++;
            customer = c;
            orderDate = DateTime.Now;
            customer.IncrementOrders();
        }
        public List<OrderDetail> GetOrderDetails()
        {
            return orderDetails;
        }

        public void AddOrderDetail(OrderDetail detail)
        {
            orderDetails.Add(detail);
        }
    }
}