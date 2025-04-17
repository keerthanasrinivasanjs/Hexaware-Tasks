using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.Util
{
    public static class DBConnUtil
    {
        // Replace this with your actual SQL Server connection string
        private static string connectionString = "Data Source=DESKTOP-0GIN3MJ;Initial Catalog=PetPalsDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static void OpenConnection(SqlConnection connection)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public static void CloseConnection(SqlConnection connection)
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}


