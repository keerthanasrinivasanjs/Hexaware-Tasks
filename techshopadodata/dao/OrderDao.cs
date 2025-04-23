using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techshopadodata.DbConn;

namespace techshopadodata.dao
{
    public class OrderDAO
    {
        private readonly DataConnector _db;
        public OrderDAO(DataConnector db) => _db = db;

        public void PlaceOrder()
        {
            Console.Write("CustomerID: "); var cid = int.Parse(Console.ReadLine());
            Console.Write("ProductID: "); var pid = int.Parse(Console.ReadLine());
            Console.Write("Quantity: "); var qty = int.Parse(Console.ReadLine());

            using (var conn = _db.OpenConnection())
            using (var cmd = new SqlCommand(
                "INSERT INTO Orders (CustomerID,ProductID,Quantity,Status) VALUES(@C,@P,@Q,'Processing')", conn))
            {
                cmd.Parameters.AddWithValue("@C", cid);
                cmd.Parameters.AddWithValue("@P", pid);
                cmd.Parameters.AddWithValue("@Q", qty);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Order placed.");

            // decrement inventory
            new InventoryDAO(_db).ManageInventoryDecrease(pid, qty);
        }

        public void ViewOrders()
        {
            Console.Write("CustomerID to view: "); var cid = int.Parse(Console.ReadLine());
            using var conn = _db.OpenConnection();
            using var cmd = new SqlCommand(
                "SELECT * FROM Orders WHERE CustomerID=@C", conn);
            cmd.Parameters.AddWithValue("@C", cid);
            using var rd = cmd.ExecuteReader();
            Console.WriteLine("\nOrders:");
            while (rd.Read())
                Console.WriteLine($"{rd["OrderID"]}: Product {rd["ProductID"]}, Qty {rd["Quantity"]}, Status {rd["Status"]}");
        }

        public void TrackOrderStatus()
        {
            Console.Write("OrderID: "); var oid = int.Parse(Console.ReadLine());
            using var conn = _db.OpenConnection();
            using var cmd = new SqlCommand(
                "SELECT Status FROM Orders WHERE OrderID=@O", conn);
            cmd.Parameters.AddWithValue("@O", oid);
            var status = cmd.ExecuteScalar()?.ToString();
            Console.WriteLine($"Order {oid} is {status}");
        }
    }
}
