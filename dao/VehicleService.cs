using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarConnectApp.dao;
using Microsoft.Data.SqlClient;


namespace CarConnect.dao
{
    public class VehicleService : IVehicleService
    {
        //private string connectionString = "Server=DESKTOP-9TP1PBR\\SQLSERVER2022;Database=CarConnect;Trusted_Connection=True;";
        string connectionString = "Server=DESKTOP-0GIN3MJ;Database=CarConnectDB;Integrated Security=True;TrustServerCertificate=True";
        // Get a vehicle by its ID
        public Vehicle GetVehicleById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vehicle WHERE VehicleID = @VehicleID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VehicleID", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Vehicle
                    {
                        VehicleID = (int)reader["VehicleID"],
                        Model = reader["Model"].ToString(),
                        Make = reader["Make"].ToString(),
                        Year = (int)reader["Year"],
                        Color = reader["Color"].ToString(),
                        RegistrationNumber = reader["RegistrationNumber"].ToString(),
                        Availability = (bool)reader["Availability"] ? 1 : 0,
                        DailyRate = (int)reader["DailyRate"]
                    };
                }
            }
            return null!;
        }

        // Get all available vehicles
        public List<Vehicle> GetAvailableVehicles()
        {
            List<Vehicle> availableVehicles = new List<Vehicle>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vehicle WHERE Availability = 1";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle
                    {
                        VehicleID = (int)reader["VehicleID"],
                        Model = reader["Model"].ToString(),
                        Make = reader["Make"].ToString(),
                        Year = (int)reader["Year"],
                        Color = reader["Color"].ToString(),
                        RegistrationNumber = reader["RegistrationNumber"].ToString(),
                        Availability = (bool)reader["Availability"] ? 1 : 0,
                        DailyRate = (int)reader["DailyRate"]

                    };
                    availableVehicles.Add(vehicle);
                }
            }

            return availableVehicles;
        }

        // Add a new vehicle
        public bool AddVehicle(Vehicle vehicle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //  Must open the connection first

                string checkQuery = "SELECT COUNT(*) FROM Vehicle WHERE RegistrationNumber = @RegNo";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@RegNo", vehicle.RegistrationNumber);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    Console.WriteLine("Vehicle with the same registration number already exists.");
                    return false; // ⛔ Should return false if duplicate
                }

                string insertQuery = @"INSERT INTO Vehicle (VehicleID, Model, Make, Year, Color, RegistrationNumber, Availability, DailyRate)
                               VALUES (@VehicleID, @Model, @Make, @Year, @Color, @RegistrationNumber, @Availability, @DailyRate)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
                insertCmd.Parameters.AddWithValue("@Model", vehicle.Model);
                insertCmd.Parameters.AddWithValue("@Make", vehicle.Make);
                insertCmd.Parameters.AddWithValue("@Year", vehicle.Year);
                insertCmd.Parameters.AddWithValue("@Color", vehicle.Color);
                insertCmd.Parameters.AddWithValue("@RegistrationNumber", vehicle.RegistrationNumber);
                insertCmd.Parameters.AddWithValue("@Availability", vehicle.Availability);
                insertCmd.Parameters.AddWithValue("@DailyRate", vehicle.DailyRate);

                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Vehicle added successfully.");
                return true;
            }
        }


        // Update an existing vehicle
        public bool UpdateVehicle(Vehicle updatedVehicle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string updateQuery = @"UPDATE Vehicle SET 
                Model = @Model, 
                Make = @Make, 
                Year = @Year, 
                Color = @Color, 
                RegistrationNumber = @RegistrationNumber, 
                Availability = @Availability, 
                DailyRate = @DailyRate 
                WHERE VehicleID = @VehicleID";

                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@VehicleID", updatedVehicle.VehicleID);
                cmd.Parameters.AddWithValue("@Model", updatedVehicle.Model);
                cmd.Parameters.AddWithValue("@Make", updatedVehicle.Make);
                cmd.Parameters.AddWithValue("@Year", updatedVehicle.Year);
                cmd.Parameters.AddWithValue("@Color", updatedVehicle.Color);
                cmd.Parameters.AddWithValue("@RegistrationNumber", updatedVehicle.RegistrationNumber);
                cmd.Parameters.AddWithValue("@Availability", updatedVehicle.Availability);
                cmd.Parameters.AddWithValue("@DailyRate", updatedVehicle.DailyRate);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAffected > 0 ? "Vehicle updated successfully." : "Vehicle not found.");
            }
            return true;
        }

        // Remove a vehicle by ID
        public void RemoveVehicle(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM Vehicle WHERE VehicleID = @VehicleID";
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@VehicleID", id);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Vehicle removed successfully." : "Vehicle not found.");
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> allVehicles = new List<Vehicle>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Vehicle"; // Fetch all vehicles
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    allVehicles.Add(new Vehicle
                    {
                        VehicleID = (int)reader["VehicleID"],
                        Model = reader["Model"].ToString()!,
                        Make = reader["Make"].ToString()!,
                        Year = (int)reader["Year"],
                        Color = reader["Color"].ToString()!,
                        RegistrationNumber = reader["RegistrationNumber"].ToString()!,
                        Availability = (bool)reader["Availability"] ? 1 : 0,
                        DailyRate = (int)reader["DailyRate"]
                    });
                }
            }

            return allVehicles;
        }
    }
}
