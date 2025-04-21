using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarConnectApp.Entity;
using System.Data;

namespace CarConnectApp.Entity
{
    public class AuthenticationService
    {
        string connectionString = "Server=DESKTOP-0GIN3MJ;Database=CarConnectDB;Integrated Security=True;Integrated Security=True;TrustServerCertificate=True";

        public Customer AuthenticateCustomer(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Assuming your Customer class has these properties
                        return new Customer
                        {
                            CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Username = reader.GetString(reader.GetOrdinal("Username")),
                            Password = reader.GetString(reader.GetOrdinal("Password")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            PhoneNumber = reader.GetString(reader.GetOrdinal("Phone"))
                        };
                    }
                }
            }

            // If no match found
            return null;
        }

       
        public Admin AuthenticateAdmin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Admin WHERE LOWER(Username) = LOWER(@Username) AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Admin
                    {
                        AdminID = (int)reader["AdminID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString(),
                        JoinDate = Convert.ToDateTime(reader["JoinDate"])
                    };
                }
                return null;
            }
        }
    }


}



    
