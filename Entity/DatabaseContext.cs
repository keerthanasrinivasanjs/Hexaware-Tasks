using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnectApp.Entity
{
    internal class DatabaseContext
    {
        private string connectionString = "Server=DESKTOP-0GIN3MJ;Database=CarConnectDB;Integrated Security=True;TrustServerCertificate=True";

        private SqlConnection connection;

        // Constructor
        public DatabaseContext()
        {
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                Console.WriteLine("Database connection opened.");
            }
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Database connection closed.");
            }
        }

        // Get the connection object (used by other classes to execute SQL)
        public SqlConnection GetConnection()
        {
            return connection;
        }

        public String GetConnectionString()
        {
            return null;
        }
    }
}

 
    
