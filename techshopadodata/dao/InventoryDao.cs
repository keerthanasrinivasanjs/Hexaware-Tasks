using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techshopadodata.DbConn;

namespace techshopadodata.dao
{
    public class InventoryDAO
    {
        private readonly DataConnector _db;
        public InventoryDAO(DataConnector db) => _db = db;

        public void ManageInventory()
        {
            Console.Write("ProductID: "); var id = int.Parse(Console.ReadLine());
            Console.Write("Quantity to add: "); var qty = int.Parse(Console.ReadLine());

            using (var conn = _db.OpenConnection())
            using (var cmd = new SqlCommand(
                "IF EXISTS (SELECT 1 FROM Inventory WHERE ProductID=@ID) " +
                "  UPDATE Inventory SET QuantityInStock += @Q WHERE ProductID=@ID " +
                "ELSE " +
                "  INSERT INTO Inventory (ProductID,QuantityInStock) VALUES(@ID,@Q)", conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Q", qty);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Inventory updated.");
        }

        public void ShowInventory()
        {
            using var conn = _db.OpenConnection();
            using var cmd = new SqlCommand("SELECT * FROM Inventory", conn);
            using var rd = cmd.ExecuteReader();
            Console.WriteLine("\nInventory:");
            while (rd.Read())
                Console.WriteLine($"Product {rd["ProductID"]}: {rd["QuantityInStock"]} in stock");
        }

        internal void ManageInventoryDecrease(int pid, int qty)
        {
            throw new NotImplementedException();
        }
    }
}