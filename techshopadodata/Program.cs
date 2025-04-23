using TechshopData.data;
using static System.Console;
using System.Collections.Generic;
using techshopadodata.dao;
using techshopadodata.DbConn;

namespace TechshopData
{
    class Program
    {
        

            static void Main()
            {
                var cs = "Data Source=DESKTOP-0GIN3MJ;Initial Catalog=TechShopDB;Integrated Security=True;";
                var db = new DataConnector(cs);

                var custDAO = new CustomerDao(db);
                var prodDAO = new ProductDAO(db);
                var invDAO = new InventoryDAO(db);
                var orderDAO = new OrderDAO(db);
                var payDAO = new PaymentDAO(db);
                var rptDAO = new ReportDAO(db);

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\n=== TechShop Menu ===");
                    Console.WriteLine("1.Register Customer\n2.Update Customer Info\n3.Add Product\n4.Update Product Price\n5.Delete Product");
                    Console.WriteLine("6.View Products\n7.Search/Recommend Products");
                    Console.WriteLine("8.Place Order\n9.View Orders\n10.Track Order Status");
                    Console.WriteLine("11.Manage Inventory\n12.Show Inventory\n13.Record Payment\n14.Generate Sales Report\n15.Exit");
                    Console.Write("Choice: ");
                    switch (Console.ReadLine())
                    {
                        case "1": custDAO.RegisterCustomer(); 
                            break;
                        case "2": custDAO.UpdateCustomerInfo();
                            break;
                        case "3": prodDAO.AddProduct(); 
                            break;
                        case "4": prodDAO.UpdateProduct();
                            break;
                        case "5": prodDAO.DeleteProduct();
                            break;
                        case "6": prodDAO.ViewAllProducts();
                            break;
                        case "7": prodDAO.SearchAndRecommend();
                             break;
                        case "8": orderDAO.PlaceOrder(); 
                              break;
                        case "9": orderDAO.ViewOrders(); 
                              break;
                        case "10": orderDAO.TrackOrderStatus()
                            ; break;
                        case "11": invDAO.ManageInventory();
                              break;
                        case "12": invDAO.ShowInventory(); 
                             break;
                        case "13": payDAO.RecordPayment(); 
                             break;

                        case "14": rptDAO.GenerateSalesReport(); 
                            break;
                        case "15": exit = true; 
                            break;
                        default: Console.WriteLine("Invalid");
                            break;
                    }
                }
            }
        }
    }