namespace ExceptionHandlling
{
    internal class Program
    {
        static void Main(string[] args)
        {
                // Sample stock for inventory management  
                Dictionary<string, int> stock = new Dictionary<string, int>
            {
                { "product1", 10 },
                { "product2", 5 },
                { "product3", 0 }
            };

                InventoryManager inventoryManager = new InventoryManager(stock);
                OrderProcessor orderProcessor = new OrderProcessor();
                PaymentProcessor paymentProcessor = new PaymentProcessor();

                while (true)
                {
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1. Validate Email");
                    Console.WriteLine("2. Process Order");
                    Console.WriteLine("3. Process Payment");
                    Console.WriteLine("4. Log Error");
                    Console.WriteLine("5. Exit");
                    Console.Write("Your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            // Validate email  
                            Console.Write("Enter your email: ");
                            string email = Console.ReadLine();
                            try
                            {
                                DataValidator.ValidateEmail(email);
                                Console.WriteLine("Email is valid.");
                            }
                            catch (InvalidDataException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;

                        case "2":
                            // Process order  
                            Console.Write("Enter product ID: ");
                            string productId = Console.ReadLine();
                            Console.Write("Enter quantity: ");
                            int quantity;
                            if (int.TryParse(Console.ReadLine(), out quantity))
                            {
                                try
                                {
                                    inventoryManager.ProcessOrder(productId, quantity);
                                    Dictionary<string, object> orderDetails = new Dictionary<string, object>
                                {
                                    { "product_reference", productId }
                                };
                                    orderProcessor.ProcessOrder(orderDetails);
                                    Console.WriteLine("Order processed successfully.");
                                }
                                catch (InsufficientStockException ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                }
                                catch (IncompleteOrderException ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid quantity entered.");
                            }
                            break;

                        case "3":
                            // Process payment  
                            Order order = new Order(); // Simplified Order object instantiation (assuming you have an Order class)  
                            try
                            {
                                paymentProcessor.ProcessPayment(order);
                                Console.WriteLine("Payment processed successfully.");
                            }
                            catch (PaymentFailedException ex)
                            {
                                Console.WriteLine($"Payment error: {ex.Message}");
                            }
                            break;

                        case "4":
                            // Log an error  
                            try
                            {
                                Logger.LogError("Sample error log message.");
                                Console.WriteLine("Error logged successfully.");
                            }
                            catch (FileIOException ex)
                            {
                                Console.WriteLine($"Logging error: {ex.Message}");
                            }
                            break;

                        case "5":
                            Console.WriteLine("Exiting the application.");
                            return;

                        default:
                            Console.WriteLine("Invalid option, please select again.");
                            break;
                    }

                    Console.WriteLine();  
                }
            }
        }

       
        public class Order
        {
           
        }
    }


