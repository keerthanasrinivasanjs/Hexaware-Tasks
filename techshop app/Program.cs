using techshop_app;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionAss
{
    class Program
    {
        // In-memory lists to store Products and Orders
        static List<Product> products = new List<Product>();
        static List<Order> orders = new List<Order>();

        static void Main(string[] args)
        {
            // Show the main menu
            ShowMenu();
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== Tech Shop Menu =====");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Add Order");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Update Order");
                Console.WriteLine("5. Exit");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        AddOrder();
                        break;
                    case "3":
                        UpdateProduct();
                        break;
                    case "4":
                        UpdateOrder();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        static void AddProduct()
        {
            try
            {
                Console.WriteLine("Enter Product Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Product Price:");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter Product SKU:");
                string sku = Console.ReadLine();

                Console.WriteLine("Enter Product Stock:");
                int stock = int.Parse(Console.ReadLine());

                int id = products.Count + 1;
                Product newProduct = new Product
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    SKU = sku,
                    Stock = stock
                };

                products.Add(newProduct);
                Console.WriteLine("Product added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void AddOrder()
        {
            try
            {
                Console.WriteLine("Enter Product ID to order:");
                int productId = int.Parse(Console.ReadLine());

                Product product = products.FirstOrDefault(p => p.Id == productId);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }

                Console.WriteLine("Enter Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                if (quantity > product.Stock)
                {
                    Console.WriteLine("Not enough stock.");
                    return;
                }

                product.Stock -= quantity;

                int orderId = orders.Count + 1;
                Order newOrder = new Order
                {
                    Id = orderId,
                    Product = product,
                    Quantity = quantity,
                    Status = "Processing",
                    OrderDate = DateTime.Now
                };

                orders.Add(newOrder);
                Console.WriteLine("Order added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void UpdateProduct()
        {
            try
            {
                Console.WriteLine("Enter Product ID to update:");
                int productId = int.Parse(Console.ReadLine());

                Product product = products.FirstOrDefault(p => p.Id == productId);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    return;
                }

                Console.WriteLine("Enter new Product Name (leave blank to keep current):");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) product.Name = name;

                Console.WriteLine("Enter new Product Price (leave blank to keep current):");
                string priceStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(priceStr)) product.Price = decimal.Parse(priceStr);

                Console.WriteLine("Enter new Product Stock (leave blank to keep current):");
                string stockStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(stockStr)) product.Stock = int.Parse(stockStr);

                Console.WriteLine("Product updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void UpdateOrder()
        {
            try
            {
                Console.WriteLine("Enter Order ID to update:");
                int orderId = int.Parse(Console.ReadLine());

                Order order = orders.FirstOrDefault(o => o.Id == orderId);
                if (order == null)
                {
                    Console.WriteLine("Order not found.");
                    return;
                }

                Console.WriteLine("Enter new Quantity (leave blank to keep current):");
                string qtyStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(qtyStr)) order.Quantity = int.Parse(qtyStr);

                Console.WriteLine("Enter new Order Status (leave blank to keep current):");
                string status = Console.ReadLine();
                if (!string.IsNullOrEmpty(status)) order.Status = status;

                Console.WriteLine("Order updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}