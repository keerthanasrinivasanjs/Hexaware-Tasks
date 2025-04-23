using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAss;

namespace techshopapp
{
    class OrderDetail
    {
        private static int idCounter = 1;
        private int orderDetailID;
        private Order order;
        private Product product;
        private int quantity;

        public int OrderDetailID => orderDetailID;
        public Order Order => order;
        public Product Product => product;
        public int Quantity
        {
            get => quantity;
            set
            {
                if (value <= 0) throw new ArgumentException("Quantity must be positive.");
                quantity = value;
            }
        }

        public OrderDetail(Order o, Product p, int q)
        {
            orderDetailID = idCounter++;
            order = o;
            product = p;
            Quantity = q;
        }
    }
}