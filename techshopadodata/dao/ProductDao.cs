using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techshopadodata.DbConn;
using TechshopData.data;

namespace techshopadodata.dao
{
    public class ProductDAO
    {
        private readonly DataConnector _db;
        public ProductDAO(DataConnector db) => _db = db;

        public void AddProduct()
        {
            Console.Write("Name: "); var name = Console.ReadLine();
            Console.Write("Description: "); var desc = Console.ReadLine();
            Console.Write("Price: "); var price = decimal.Parse(Console.ReadLine());
            Console.Write("SKU: "); var sku = Console.ReadLine();

            using (var conn = _db.OpenConnection())
            using (var cmd = new SqlCommand(
                "INSERT INTO Products (ProductName,Description,Price,SKU) VALUES (@N,@D,@P,@S)", conn))
            {
                cmd.Parameters.AddWithValue("@N", name);
                cmd.Parameters.AddWithValue("@D", desc);
                cmd.Parameters.AddWithValue("@P", price);
                cmd.Parameters.AddWithValue("@S", sku);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Product added.");
        }

        public void UpdateProduct()
        {
            Console.Write("ProductID: "); var id = int.Parse(Console.ReadLine());
            Console.Write("New Price: "); var price = decimal.Parse(Console.ReadLine());
            Console.Write("New Stock?");    // stock handled in InventoryDAO
            using (var conn = _db.OpenConnection())
            using (var cmd = new SqlCommand(
                "UPDATE Products SET Price=@P WHERE ProductID=@ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@P", price);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Product price updated.");
        }

        public void DeleteProduct()
        {
            Console.Write("ProductID to delete: ");
            var id = int.Parse(Console.ReadLine());
            using (var conn = _db.OpenConnection())
            using (var cmd = new SqlCommand(
                "DELETE FROM Products WHERE ProductID=@ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Product deleted.");
        }

        public void SearchAndRecommend()
        {
            Console.Write("Search keyword: ");
            var kw = Console.ReadLine();
            var list = new List<Product>();
            using (var conn = _db.OpenConnection())
            using (var cmd = new SqlCommand(
                "SELECT TOP 10 * FROM Products WHERE ProductName LIKE @K", conn))
            {
                cmd.Parameters.AddWithValue("@K", $"%{kw}%");
                using var rd = cmd.ExecuteReader();
                while (rd.Read())
                    list.Add(new Product
                    {
                        ProductID = (int)rd["ProductID"],
                        ProductName = rd["ProductName"].ToString(),
                        Description = rd["Description"].ToString(),
                        Price = (decimal)rd["Price"],
                        SKU = rd["SKU"].ToString()
                    });
            }
            Console.WriteLine("\nSearch Results:");
            foreach (var p in list)
                Console.WriteLine($"{p.ProductID}: {p.ProductName} – ₹{p.Price}");

            Console.WriteLine("\nRecommended (Top 3):");
            foreach (var p in list.Take(3))
                Console.WriteLine($"{p.ProductID}: {p.ProductName}");
        }

        public void ViewAllProducts()
        {
            using (var conn = _db.OpenConnection())
            using (var cmd = new SqlCommand("SELECT * FROM Products", conn))
            using (var rd = cmd.ExecuteReader())
            {
                Console.WriteLine("\nAll Products:");
                while (rd.Read())
                    Console.WriteLine($"{rd["ProductID"]}: {rd["ProductName"]} – ₹{rd["Price"]}");
            }
        }
    }
}