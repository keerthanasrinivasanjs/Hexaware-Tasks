using System;
using CarConnectApp.Entity;
using System.Data.SqlClient;
using CarConnect.dao;


namespace CarConnectApp.dao
{
    public class CustomerService : ICustomerService
    {
        // public string connectionString = "Server=DESKTOP-9TP1PBR\\SQLSERVER2022;Database=CarConnect;Trusted_Connection=True;";
        string connectionString = "Server=DESKTOP-0GIN3MJ;Database=CarConnectDB;Integrated Security=True;Integrated Security=True;TrustServerCertificate=True";

        public Customer GetCustomerById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer WHERE CustomerID = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        FirstName = reader["FirstName"].ToString()!,
                        LastName = reader["LastName"].ToString()!,
                        Email = reader["Email"].ToString()!,
                        PhoneNumber = reader["PhoneNumber"].ToString()!,
                        Address = reader["Address"].ToString()!,
                        Username = reader["Username"].ToString()!,
                        Password = reader["Password"].ToString()!,
                        RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                    };
                }
            }
            return null!;
        }

        public Customer GetCustomerByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer WHERE LOWER(Username) = LOWER(@Username)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                    };
                }
            }
            return null!;
        }

        public void RegisterCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT COUNT(*) FROM Customer WHERE Username = @Username OR Email = @Email";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Username", customer.Username);
                checkCommand.Parameters.AddWithValue("@Email", customer.Email);

                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();
                if (count > 0)
                {
                    Console.WriteLine("Username or Email already exists.");
                    return;
                }

                string insertQuery = @"INSERT INTO Customer (CustomerID,FirstName, LastName, Email, PhoneNumber, Address, Username, Password, RegistrationDate)
                                   VALUES (@CustomerID,@FirstName, @LastName, @Email, @PhoneNumber, @Address, @Username, @Password, @RegistrationDate)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                insertCommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
                insertCommand.Parameters.AddWithValue("@LastName", customer.LastName);
                insertCommand.Parameters.AddWithValue("@Email", customer.Email);
                insertCommand.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                insertCommand.Parameters.AddWithValue("@Address", customer.Address);
                insertCommand.Parameters.AddWithValue("@Username", customer.Username);
                insertCommand.Parameters.AddWithValue("@Password", customer.Password);
                insertCommand.Parameters.AddWithValue("@RegistrationDate", customer.RegistrationDate);

                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Customer registered successfully.");
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string updateQuery = @"UPDATE Customer SET FirstName = @FirstName, LastName = @LastName,
                        Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address,
                        Username = @Username, Password = @Password, RegistrationDate = @RegistrationDate
                        WHERE CustomerID = @CustomerID";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@Username", customer.Username);
                command.Parameters.AddWithValue("@Password", customer.Password);
                command.Parameters.AddWithValue("@RegistrationDate",
                    customer.RegistrationDate < new DateTime(1753, 1, 1)
                    ? DateTime.Now
                    : customer.RegistrationDate);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Customer updated successfully." : "Customer not found.");
                return rows > 0;
            }
        }


        public void DeleteCustomer(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM Customer WHERE CustomerID = @CustomerID";
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@CustomerID", id);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Customer deleted successfully." : "Customer not found.");
            }
        }
    }
}

