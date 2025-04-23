namespace CollectionAss
{
    internal class Program
    {
        class Product
        {
            public int Id;
            public string Name;
            public decimal Price;
            public string SKU;
            public int Stock;
        }

        class Order
        {
            public int Id;
            public Product Product;
            public int Quantity;
            public string Status;
            public DateTime OrderDate;
        }

        class Payment
        {
            public int OrderId;
            public decimal Amount;
            public string Status;
        }

        static List<Product> products = new List<Product>();
        static SortedList<int, int> inventory = new SortedList<int, int>();
        static List<Order> orders = new List<Order>();
        static List<Payment> payments = new List<Payment>();

        static void Main()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("====== TechShop Menu ======");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Remove Product");
                Console.WriteLine("4. Place Order");
                Console.WriteLine("5. Update Order Status");
                Console.WriteLine("6. Cancel Order");
                Console.WriteLine("7. Search Product");
                Console.WriteLine("8. Show Sorted Orders by Date");
                Console.WriteLine("9. View Inventory");
                Console.WriteLine("10. View All Payments");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                switch (Console.ReadLine())
                {
                    case "1": AddProduct(); break;
                    case "2": UpdateProduct(); break;
                    case "3": RemoveProduct(); break;
                    case "4": PlaceOrder(); break;
                    case "5": UpdateOrderStatus(); break;
                    case "6": CancelOrder(); break;
                    case "7": SearchProduct(); break;
                    case "8": ShowSortedOrders(); break;
                    case "9": ShowInventory(); break;
                    case "10": ShowPayments(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Invalid option!"); break;
                }
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static void AddProduct()
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter SKU: ");
            string sku = Console.ReadLine();

            if (products.Any(p => p.SKU == sku))
            {
                Console.WriteLine("Error: Duplicate product SKU.");
                return;
            }

            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Stock: ");
            int stock = int.Parse(Console.ReadLine());

            int id = products.Count + 1;
            var product = new Product { Id = id, Name = name, SKU = sku, Price = price, Stock = stock };
            products.Add(product);
            inventory[id] = stock;

            Console.WriteLine("Product added successfully.");
        }

        static void UpdateProduct()
        {
            Console.Write("Enter Product ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) { Console.WriteLine("Product not found."); return; }

            Console.Write("Enter new Price: ");
            product.Price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter new Stock: ");
            product.Stock = int.Parse(Console.ReadLine());
            inventory[product.Id] = product.Stock;

            Console.WriteLine("Product updated successfully.");
        }

        static void RemoveProduct()
        {
            Console.Write("Enter Product ID to remove: ");
            int id = int.Parse(Console.ReadLine());

            if (orders.Any(o => o.Product.Id == id))
            {
                Console.WriteLine("Error: Cannot remove product with existing orders.");
                return;
            }

            products.RemoveAll(p => p.Id == id);
            inventory.Remove(id);
            Console.WriteLine("Product removed successfully.");
        }

        static void PlaceOrder()
        {
            Console.Write("Enter Product ID: ");
            int pid = int.Parse(Console.ReadLine());
            var product = products.FirstOrDefault(p => p.Id == pid);
            if (product == null) { Console.WriteLine("Product not found."); return; }

            Console.Write("Enter Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            if (inventory[pid] < qty)
            {
                Console.WriteLine("Error: Insufficient stock.");
                return;
            }

            inventory[pid] -= qty;
            product.Stock -= qty;

            int oid = orders.Count + 1;
            var order = new Order
            {
                Id = oid,
                Product = product,
                Quantity = qty,
                Status = "Completed",
                OrderDate = DateTime.Now
            };
            orders.Add(order);

            payments.Add(new Payment
            {
                OrderId = oid,
                Amount = product.Price * qty,
                Status = "Paid"
            });

            Console.WriteLine("Order placed successfully.");
        }

        static void UpdateOrderStatus()
        {
            Console.Write("Enter Order ID to update: ");
            int oid = int.Parse(Console.ReadLine());
            var order = orders.FirstOrDefault(o => o.Id == oid);
            if (order == null) { Console.WriteLine("Order not found."); return; }

            Console.Write("Enter new status (Completed/Processing): ");
            order.Status = Console.ReadLine();
            Console.WriteLine("Order status updated.");
        }

        static void CancelOrder()
        {
            Console.Write("Enter Order ID to cancel: ");
            int oid = int.Parse(Console.ReadLine());
            var order = orders.FirstOrDefault(o => o.Id == oid);
            if (order == null) { Console.WriteLine("Order not found."); return; }

            order.Status = "Cancelled";
            inventory[order.Product.Id] += order.Quantity;
            order.Product.Stock += order.Quantity;

            Console.WriteLine("Order cancelled and inventory updated.");
        }

        static void SearchProduct()
        {
            Console.Write("Enter search keyword: ");
            string keyword = Console.ReadLine().ToLower();

            var result = products.Where(p => p.Name.ToLower().Contains(keyword)).ToList();
            if (result.Count == 0)
            {
                Console.WriteLine("No matching products found.");
                return;
            }

            foreach (var p in result)
                Console.WriteLine($"[{p.Id}] {p.Name} - ₹{p.Price} (Stock: {p.Stock})");
        }

        static void ShowSortedOrders()
        {
            Console.WriteLine("Sorted Orders by Date:");
            foreach (var o in orders.OrderBy(o => o.OrderDate))
                Console.WriteLine($"Order #{o.Id} - {o.Product.Name} - Qty: {o.Quantity} - {o.Status} - {o.OrderDate}");
        }

        static void ShowInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (var kvp in inventory)
            {
                var product = products.FirstOrDefault(p => p.Id == kvp.Key);
                if (product != null)
                    Console.WriteLine($"{product.Name} (ID: {kvp.Key}) - Stock: {kvp.Value}");
            }
        }

        static void ShowPayments()
        {
            Console.WriteLine("Payment Records:");
            foreach (var p in payments)
                Console.WriteLine($"Order ID: {p.OrderId} - ₹{p.Amount} - {p.Status}");
        }
    }
}