using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace LoanManagement.util
{
   
        public class DBConnUtil
        {
            // Static method to get DB connection
            public static SqlConnection GetDBConn()
            {
                try
                {
                    // Hardcoded connection string (adjust it according to your database)
                    string connectionString =  "Server=DESKTOP-0GIN3MJ;Database=loansystem;Integrated Security=True;TrustServerCertificate=True;";

                // Create and return the connection
                SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    return connection;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error establishing database connection: " + ex.Message);
                    throw;
                }
            }
        }
    }
