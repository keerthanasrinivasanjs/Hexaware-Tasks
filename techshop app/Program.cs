using techshopapp;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CollectionAss
{
    using System;
    using System.Collections.Generic;

    namespace techshopapp
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Customer> customers = new List<Customer>();
                List<Product> products = new List<Product>();
                List<Order> orders = new List<Order>();
                List<Inventory> inventoryList = new List<Inventory>();

                while (true)
                {
                    Console.WriteLine("\n--- TechShop Main Menu ---");
                    Console.WriteLine("1. Add Customer");
                    Console.WriteLine("2. Add Product");
                    Console.WriteLine("3. Place Order");
                    Console.WriteLine("4. View Inventory");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine("6. View All Customers");
                    Console.WriteLine("7. View All Products");
                    Console.WriteLine("8. View All Orders");

                    Console.Write("Choose an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Enter Last Name: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Enter Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Enter Phone: ");
                            string phone = Console.ReadLine();
                            Console.Write("Enter Address: ");
                            string address = Console.ReadLine();

                            Customer newCustomer = new Customer(firstName, lastName, email, phone, address);
                            customers.Add(newCustomer);
                            Console.WriteLine("Customer added successfully.");
                            break;

                        case 2:
                            Console.Write("Enter Product Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Description: ");
                            string desc = Console.ReadLine();
                            Console.Write("Enter Price: ");
                            decimal price = decimal.Parse(Console.ReadLine());

                            Product newProduct = new Product(name, desc, price);
                            products.Add(newProduct);
                            inventoryList.Add(new Inventory(newProduct, 0));
                            Console.WriteLine("Product added successfully.");
                            break;

                        case 3:
                            if (customers.Count == 0 || products.Count == 0)
                            {
                                Console.WriteLine("Add customers and products first.");
                                break;
                            }
                            Console.WriteLine("Select Customer by ID:");
                            foreach (var c in customers) Console.WriteLine(c.CustomerID + ": " + c.FirstName);
                            int custId = int.Parse(Console.ReadLine());
                            Customer customer = customers.Find(c => c.CustomerID == custId);

                            List<OrderDetail> details = new List<OrderDetail>();
                            while (true)
                            {
                                Console.WriteLine("Select Product by ID:");
                                foreach (var p in products) Console.WriteLine(p.ProductID + ": " + p.ProductName);
                                int prodId = int.Parse(Console.ReadLine());
                                Product product = products.Find(p => p.ProductID == prodId);
                                Console.Write("Enter Quantity: ");
                                int qty = int.Parse(Console.ReadLine());

                                Order orderRef = new Order(customer);
                                OrderDetail od = new OrderDetail(orderRef, product, qty);
                                details.Add(od);

                                Console.Write("Add more products? (y/n): ");
                                if (Console.ReadLine().ToLower() != "y") break;
                            }

                            Order newOrder = new Order(customer);
                            foreach (var d in details) newOrder.AddOrderDetail(d);
                            orders.Add(newOrder);
                            Console.WriteLine("Order placed.");
                            break;

                        case 4:
                            foreach (var inv in inventoryList)
                                Console.WriteLine($"{inv.Product.ProductName}: {inv.QuantityInStock} units");
                            break;

                        case 5:
                            return;

                        case 6:
                            if (customers.Count == 0)
                                Console.WriteLine("No customers available.");
                            else
                            {
                                Console.WriteLine("Customer List:");
                                foreach (var c in customers)
                                    Console.WriteLine("------------------\n" + c.GetCustomerDetails());
                            }
                            break;
                        case 7:
                            if (products.Count == 0)
                                Console.WriteLine("No products available.");
                            else
                            {
                                Console.WriteLine("Product List:");
                                foreach (var p in products)
                                {
                                    Console.WriteLine($"ID: {p.ProductID}\nName: {p.ProductName}\nDescription: {p.Description}\nPrice: {p.Price:C}\n------------------");
                                }
                            }
                            break;

                        case 8:
                            if (orders.Count == 0)
                                Console.WriteLine("No orders placed yet.");
                            else
                            {
                                Console.WriteLine("Order List:");
                                foreach (var order in orders)
                                {
                                    Console.WriteLine($"\nOrder ID: {order.OrderID}");
                                    Console.WriteLine($"Customer: {order.Customer.FirstName} {order.Customer.LastName}");
                                    Console.WriteLine($"Order Date: {order.OrderDate}");

                                    // Reflecting each order's details
                                    foreach (var od in order.GetOrderDetails())
                                    {
                                        Console.WriteLine($"  - Product: {od.Product.ProductName}, Quantity: {od.Quantity}, Price: {od.Product.Price:C}");
                                    }
                                    Console.WriteLine("----------------------------");
                                }
                            }
                            break;


                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
            }
        }
    }
}


       

       

       
       