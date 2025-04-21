using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnectApp.Entity
{
    internal class ReportGenerator
    {
        private string connectionString = "Server=DESKTOP-0GIN3MJ;Database=CarConnectDB;Integrated Security=True;TrustServerCertificate=True";

        // Method 1: Calculate total revenue from all reservations
        public int GetTotalRevenue()
        {
            int total = 0;
            string query = "SELECT TotalCost FROM Reservation";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["TotalCost"] != DBNull.Value)
                        {
                            total += Convert.ToInt32(reader["TotalCost"]);
                        }
                    }
                }
            }

            return total;
        }

        // Method 2: Get reserved vehicle models
        public List<string> GetReservedVehicleModels()
        {
            List<string> models = new List<string>();
            string query = @"
        SELECT DISTINCT V.Model
        FROM Vehicle V
        INNER JOIN Reservation R ON V.VehicleID = R.VehicleID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var model = reader["Model"]?.ToString();
                            if (!string.IsNullOrEmpty(model))
                            {
                                models.Add(model);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return models;
        }

        // Method 3: Print count of each reservation status
        public void PrintReservationStatusCount()
        {
            int pending = 0, confirmed = 0, completed = 0;
            string query = "SELECT Status FROM Reservation";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string status = reader["Status"].ToString();
                        switch (status)
                        {
                            case "Pending": pending++; break;
                            case "Confirmed": confirmed++; break;
                            case "Completed": completed++; break;
                        }
                    }
                }
            }

            Console.WriteLine("\n--- Reservation Status Report ---");
            Console.WriteLine($"Pending:   {pending}");
            Console.WriteLine($"Confirmed: {confirmed}");
            Console.WriteLine($"Completed: {completed}");
        }
    }

}

