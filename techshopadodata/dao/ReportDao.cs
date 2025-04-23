using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techshopadodata.DbConn;

namespace techshopadodata.dao
{
    public class ReportDAO
    {
        private readonly DataConnector _db;
        public ReportDAO(DataConnector db) => _db = db;

        public void GenerateSalesReport()
        {
            using var conn = _db.OpenConnection();
            using var cmd = new SqlCommand("SELECT SUM(Amount) FROM Payments", conn);
            var total = cmd.ExecuteScalar();
            Console.WriteLine($"Total Sales: ₹{total}");
        }
    }
}
