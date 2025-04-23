using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techshopadodata.DbConn;

namespace techshopadodata.dao
{
    public class CustomerDao
    {
        private readonly DataConnector _db;
        public CustomerDao(DataConnector db) => _db = db;

        public void RegisterCustomer()
        {
            Console.Write("Name: "); var name = Console.ReadLine();
            Console.Write("Email: "); var email = Console.ReadLine();
            Console.Write("Phone: "); var phone = Console.ReadLine();

            using (var conn = _db.OpenConnection())
            using (var cmd = new SqlCommand(
                "INSERT INTO Customers (Name,Email,Phone) VALUES (@N,@E,@P)", conn))
            {
                cmd.Parameters.AddWithValue("@N", name);
                cmd.Parameters.AddWithValue("@E", email);
                cmd.Parameters.AddWithValue("@P", phone);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Customer registered.");
        }

        public void UpdateCustomerInfo()
        {
            Console.Write("CustomerID: "); var id = int.Parse(Console.ReadLine());
            Console.Write("New Email: "); var email = Console.ReadLine();
            Console.Write("New Phone: "); var phone = Console.ReadLine();

            using (var conn = _db.OpenConnection())
            using (var cmd = new SqlCommand(
                "UPDATE Customers SET Email=@E,Phone=@P WHERE CustomerID=@ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@E", email);
                cmd.Parameters.AddWithValue("@P", phone);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Customer info updated.");
        }
    }
}
