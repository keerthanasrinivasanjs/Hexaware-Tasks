using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPalsApp.Entity;
using PetPalsApp.MainModule;
using PetPalsApp.Util;

namespace PetPalsApp.dao
{
    public class AdoptionEvent
    {
        private List<IAdoptable> participants = new List<IAdoptable>();

        public void RegisterParticipant(IAdoptable adoptable)
        {
            participants.Add(adoptable);
        }

        public void HostEvent()
        {
            if (participants.Count == 0)
            {
                Console.WriteLine("No pets registered for the adoption event.");
                return;
            }

            Console.WriteLine("Adoption Event in Live!");

            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                foreach (var participant in participants)
                {
                    string query = "INSERT INTO AdoptionEvents (EventDate, PetName) VALUES (@EventDate, @PetName)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EventDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@PetName", participant.Name); // Access the Name property from the interface
                        cmd.ExecuteNonQuery();
                    }
                }
            }
       

            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                foreach (var participant in participants)
                {
                    participant.Adopt();

                    string query = "INSERT INTO AdoptionEvents (EventDate, PetName) VALUES (@EventDate, @PetName)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EventDate", DateTime.Now);
                        if (participant is AdoptablePet ap)
                        {
                            cmd.Parameters.AddWithValue("@PetName", ap.GetName());
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@PetName", "Unknown");
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            participants.Clear();
        }
    }
}