using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPalsApp.dao;
using PetPalsApp.Entity;
using PetPalsApp.exception;

namespace PetPalsApp.MainModule
{

        class MainModule
        {
            static PetShelter shelter = new PetShelter();
            static AdoptionEvent adoptionEvent = new AdoptionEvent();

            static void Main(string[] args)
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\n=== Welcome to PetPals Adoption Platform ===");
                    Console.WriteLine("1. Add Pet");
                    Console.WriteLine("2. List Available Pets");
                    Console.WriteLine("3. Adopt a Pet");
                    Console.WriteLine("4. Make a Donation");
                    Console.WriteLine("5. Host Adoption Event");
                    Console.WriteLine("6. Exit");
                    Console.Write("Choose an option (1-6): ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddPetMenu();
                            break;
                        case "2":
                            shelter.ListAvailablePets();
                            break;
                        case "3":
                            AdoptPet();
                            break;
                        case "4":
                            DonationMenu();
                            break;
                        case "5":
                            HostAdoptionEvent();
                            break;
                        case "6":
                            exit = true;
                            Console.WriteLine("Thank you for visiting PetPals!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
            }

            static void AddPetMenu()
            {
                Console.WriteLine("\n--- Add a Pet ---");
                Console.WriteLine("1. Dog");
                Console.WriteLine("2. Cat");
                Console.Write("Select Pet Type (1/2): ");
                string type = Console.ReadLine();

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    Console.WriteLine("Invalid age.");
                    return;
                }

                if (age < 0)
                {
                    throw new InvalidPetAgeException("Pet age cannot be negative.");
                }

                Console.Write("Enter Breed: ");
                string breed = Console.ReadLine();

                if (type == "1")
                {
                    Console.Write("Enter Dog Breed: ");
                    string dogBreed = Console.ReadLine();
                    shelter.AddPet(new Dog(name, age, breed, dogBreed));
                    Console.WriteLine("Dog added successfully!");
                }
                else if (type == "2")
                {
                    Console.Write("Enter Cat Color: ");
                    string color = Console.ReadLine();
                    shelter.AddPet(new Cat(name, age, breed, color));
                    Console.WriteLine("Cat added successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid pet type.");
                }
            }

           static  void AdoptPet()
            {
                if (shelter.availablePets.Count == 0)
                {
                    Console.WriteLine("No pets available for adoption.");
                    return;
                }

                Console.WriteLine("\n--- Adopt a Pet ---");
                shelter.ListAvailablePets();

                Console.Write("Enter the name of the pet to adopt: ");
                string name = Console.ReadLine();

                Pet petToAdopt = shelter.availablePets.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (petToAdopt != null)
                {
                    adoptionEvent.RegisterParticipant(new AdoptablePet(petToAdopt));
                    shelter.RemovePet(petToAdopt);
                    Console.WriteLine($"You have successfully adopted {petToAdopt.Name}!");
                }
                else
                {
                    throw new AdoptionException("Pet not found. Please check the name and try again.");
                }
            }

            static void DonationMenu()
            {
                Console.WriteLine("\n--- Make a Donation ---");
                Console.Write("Enter Donor Name: ");
                string donorName = Console.ReadLine();

                Console.Write("Enter Amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
                {
                    throw new InsufficientFundsException("Donation amount must be greater than zero.");
                }

                Console.WriteLine("Donation Type:");
                Console.WriteLine("1. Cash");
                Console.WriteLine("2. Item");
                Console.Write("Choose type (1/2): ");
                string type = Console.ReadLine();

                Donation donation;

                if (type == "1")
                {
                    donation = new CashDonation(donorName, amount, DateTime.Now);
                }
                else if (type == "2")
                {
                    Console.Write("Enter Item Type: ");
                    string itemType = Console.ReadLine();
                    donation = new ItemDonation(donorName, amount, itemType);
                }
                else
                {
                    Console.WriteLine("Invalid donation type.");
                    return;
                }

                donation.RecordDonation();
            }

            static void HostAdoptionEvent()
            {
                Console.WriteLine("\n--- Hosting Adoption Event ---");
                adoptionEvent.HostEvent();
            }
        }

        class AdoptablePet : IAdoptable
        {
            private Pet pet;

            public AdoptablePet(Pet pet)
            {
                this.pet = pet;
            }

        public string Name => ((IAdoptable)pet).Name;

        public void Adopt()
            {
                Console.WriteLine($"{pet.Name} the {pet.GetType().Name} has been adopted!");
            }

        internal object GetName()
        {
            throw new NotImplementedException();
        }
    }
  }

