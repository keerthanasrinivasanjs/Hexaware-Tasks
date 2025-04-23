using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techshopadodata.DbConn;
using techshopadodata.Entity;

namespace techshopadodata.dao
{
    public class PaymentDAO
    {
        private readonly DataConnector _db;
        public PaymentDAO(DataConnector db) => _db = db;

        public void RecordPayment()
        {
            Console.Write("OrderID: "); var oid = int.Parse(Console.ReadLine());
            Console.Write("Amount: ₹"); var amt = decimal.Parse(Console.ReadLine());
            Console.Write("Method (Card/Cash): "); var m = Console.ReadLine();

            using var conn = _db.OpenConnection();
            using var cmd = new SqlCommand(
                "INSERT INTO Payments (OrderID,Amount,PaymentMethod) VALUES(@O,@A,@M)", conn);
            cmd.Parameters.AddWithValue("@O", oid);
            cmd.Parameters.AddWithValue("@A", amt);
            cmd.Parameters.AddWithValue("@M", m);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Payment recorded.");
        }
    }
}