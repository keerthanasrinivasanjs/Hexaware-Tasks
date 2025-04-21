using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CarConnectApp.dao;
using CarConnectApp.Entity;
class AdminService : IAdminService
{
    // private string connectionString = "Server=DESKTOP-9TP1PBR\\SQLSERVER2022;Database=CarConnect;Trusted_Connection=True;";
    string connectionString = "Server=DESKTOP-0GIN3MJ;Database=CarConnectDB;Integrated Security=True;Integrated Security=True;TrustServerCertificate=True";



    public Admin GetAdminById(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Admin WHERE AdminID = @AdminID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AdminID", id);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
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
                    JoinDate = (DateTime)reader["JoinDate"]
                };
            }
        }
        return null!;
    }

    public Admin GetAdminByUsername(string username)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Admin WHERE LOWER(Username) = LOWER(@Username)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
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
                    JoinDate = (DateTime)reader["JoinDate"]
                };
            }
        }
        return null!;
    }

    public void RegisterAdmin(Admin admin)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string checkQuery = "SELECT COUNT(*) FROM Admin WHERE Username = @Username OR Email = @Email";
            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
            checkCommand.Parameters.AddWithValue("@Username", admin.Username);
            checkCommand.Parameters.AddWithValue("@Email", admin.Email);

            connection.Open();
            int count = (int)checkCommand.ExecuteScalar();
            if (count > 0)
            {
                throw new Exception("Username or Email already exists.");
            }

            string insertQuery = @"INSERT INTO Admin (FirstName, LastName, Email, PhoneNumber, Username, Password, Role, JoinDate)
                                   VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Username, @Password, @Role, @JoinDate)";
            SqlCommand command = new SqlCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@FirstName", admin.FirstName);
            command.Parameters.AddWithValue("@LastName", admin.LastName);
            command.Parameters.AddWithValue("@Email", admin.Email);
            command.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
            command.Parameters.AddWithValue("@Username", admin.Username);
            command.Parameters.AddWithValue("@Password", admin.Password);
            command.Parameters.AddWithValue("@Role", admin.Role);
            command.Parameters.AddWithValue("@JoinDate", admin.JoinDate);

            command.ExecuteNonQuery();
            Console.WriteLine("Admin registered successfully.");
        }
    }

    public void UpdateAdmin(Admin updatedAdmin)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string updateQuery = @"UPDATE Admin SET FirstName = @FirstName, LastName = @LastName,
                                   Email = @Email, PhoneNumber = @PhoneNumber, Username = @Username,
                                   Password = @Password, Role = @Role, JoinDate = @JoinDate
                                   WHERE AdminID = @AdminID";

            SqlCommand command = new SqlCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@AdminID", updatedAdmin.AdminID);
            command.Parameters.AddWithValue("@FirstName", updatedAdmin.FirstName);
            command.Parameters.AddWithValue("@LastName", updatedAdmin.LastName);
            command.Parameters.AddWithValue("@Email", updatedAdmin.Email);
            command.Parameters.AddWithValue("@PhoneNumber", updatedAdmin.PhoneNumber);
            command.Parameters.AddWithValue("@Username", updatedAdmin.Username);
            command.Parameters.AddWithValue("@Password", updatedAdmin.Password);
            command.Parameters.AddWithValue("@Role", updatedAdmin.Role);
            command.Parameters.AddWithValue("@JoinDate", updatedAdmin.JoinDate);

            connection.Open();
            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Admin updated successfully." : "Admin not found.");
        }
    }

    public void DeleteAdmin(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string deleteQuery = "DELETE FROM Admin WHERE AdminID = @AdminID";
            SqlCommand command = new SqlCommand(deleteQuery, connection);
            command.Parameters.AddWithValue("@AdminID", id);

            connection.Open();
            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Admin deleted successfully." : "Admin not found.");
        }
    }
}


       