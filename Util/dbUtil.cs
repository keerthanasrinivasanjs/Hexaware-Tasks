using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnectApp.Util
{
    class dbUtil
    {
        public static SqlConnection GetDBConn()
        {
            string connectionString = "Server=DESKTOP-0GIN3MJ;Database=CarConnectDB;Integrated Security=True;Integrated Security=True;TrustServerCertificate=True";

            SqlConnection connection = null!;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine(" Database connection established successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
            }
            return connection;
        }
    }
}

