using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarConnectApp.Entity;

namespace CarConnectApp.dao
{
    internal class ReservationService:IReservationService
    {
        private string connectionString = "Server=DESKTOP-0GIN3MJ;Database=CarConnectDB;Integrated Security=True;TrustServerCertificate=True";

        public Reservation GetReservationById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Reservation WHERE ReservationID = @ReservationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationID", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Reservation
                    {
                        ReservationID = (int)reader["ReservationId"],
                        CustomerID = (int)reader["CustomerID"],
                        VehicleID = (int)reader["VehicleID"],
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        TotalCost = (int)reader["TotalCost"],
                        Status = reader["Status"].ToString()
                    };
                }
            }
            return null;
        }

        public List<Reservation> GetReservationsByCustomerId(int customerId)
        {
            List<Reservation> reservations = new List<Reservation>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Reservation WHERE CustomerID = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Reservation reservation = new Reservation
                    {
                        ReservationID = (int)reader["ReservationId"],
                        CustomerID = (int)reader["CustomerID"],
                        VehicleID = (int)reader["VehicleID"],
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        TotalCost = (int)reader["TotalCost"],
                        Status = reader["Status"].ToString()
                    };
                    reservations.Add(reservation);
                }
            }

            return reservations;
        }

        public void CreateReservation(Reservation reservation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Reservation (CustomerID, VehicleID, StartDate, EndDate, TotalCost, Status)
                             VALUES (@CustomerID, @VehicleID, @StartDate, @EndDate, @TotalCost, @Status)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", reservation.CustomerID);
                command.Parameters.AddWithValue("@VehicleID", reservation.VehicleID);
                command.Parameters.AddWithValue("@StartDate", reservation.StartDate);
                command.Parameters.AddWithValue("@EndDate", reservation.EndDate);
                command.Parameters.AddWithValue("@TotalCost", reservation.TotalCost);
                command.Parameters.AddWithValue("@Status", reservation.Status);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Reservation created successfully.");
            }
        }

        public void UpdateReservation(Reservation updatedReservation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Reservation 
                             SET CustomerID = @CustomerID, VehicleID = @VehicleID,
                                 StartDate = @StartDate, EndDate = @EndDate,
                                 TotalCost = @TotalCost, Status = @Status
                             WHERE ReservationID = @ReservationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", updatedReservation.CustomerID);
                command.Parameters.AddWithValue("@VehicleID", updatedReservation.VehicleID);
                command.Parameters.AddWithValue("@StartDate", updatedReservation.StartDate);
                command.Parameters.AddWithValue("@EndDate", updatedReservation.EndDate);
                command.Parameters.AddWithValue("@TotalCost", updatedReservation.TotalCost);
                command.Parameters.AddWithValue("@Status", updatedReservation.Status);
                command.Parameters.AddWithValue("@ReservationId", updatedReservation.ReservationID);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Reservation updated successfully." : "Reservation not found.");
            }
        }

        public void CancelReservation(int reservationId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Reservation SET Status = 'Cancelled' WHERE ReservationID = @ReservationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationId", reservationId);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Reservation cancelled successfully." : "Reservation not found.");
            }
        }

    }
}

    