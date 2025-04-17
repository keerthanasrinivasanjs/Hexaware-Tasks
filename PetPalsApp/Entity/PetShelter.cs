using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPalsApp.Util;

namespace PetPalsApp.Entity
{
    public class PetShelter
    {
        public List<Pet> availablePets = new List<Pet>();

        public void AddPet(Pet pet)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Pets (Name, Age, Breed, PetType, DogBreed, CatColor) VALUES (@Name, @Age, @Breed, @PetType, @DogBreed, @CatColor)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", pet.Name);
                cmd.Parameters.AddWithValue("@Age", pet.Age);
                cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                cmd.Parameters.AddWithValue("@PetType", pet is Dog ? "Dog" : "Cat");

                if (pet is Dog dog)
                {
                    cmd.Parameters.AddWithValue("@DogBreed", dog.DogBreed);
                    cmd.Parameters.AddWithValue("@CatColor", DBNull.Value);
                }
                else if (pet is Cat cat)
                {
                    cmd.Parameters.AddWithValue("@DogBreed", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatColor", cat.Color);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DogBreed", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CatColor", DBNull.Value);
                }

                cmd.ExecuteNonQuery();
                availablePets.Add(pet);
            }
        }
        public void RemovePet(Pet pet)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Pets WHERE Name = @Name"; //  It's generally better to use the Pet's ID (if you have one) for deletion, rather than the Name, to avoid issues if two pets have the same name.
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", pet.Name); //  Again, use ID if possible.
                cmd.ExecuteNonQuery();
            }
            availablePets.Remove(pet); // Remove from the in-memory list
        }

        public void ListAvailablePets()
        {
            availablePets.Clear();

            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT Name, Age, Breed, PetType, DogBreed, CatColor FROM Pets";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    int age = reader.GetInt32(1);
                    string breed = reader.GetString(2);
                    string type = reader.GetString(3);

                    Pet pet;
                    if (type == "Dog")
                    {
                        string dogBreed = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        pet = new Dog(name, age, breed, dogBreed);
                    }
                    else
                    {
                        string catColor = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        pet = new Cat(name, age, breed, catColor);
                    }

                    availablePets.Add(pet);
                }

                reader.Close();
            }

            foreach (Pet pet in availablePets)
            {
                Console.WriteLine(pet);
            }
        }
    }
}