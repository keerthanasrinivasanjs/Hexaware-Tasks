using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPalsApp.dao;

namespace PetPalsApp.Entity
{
    public class Pet : IAdoptable  // Implement the interface
    {
        public string Name { get; set; } // Implement the Name property
        public int Age { get; set; }
        public string Breed { get; set; }

        public Pet(string name, int age, string breed)
        {
            Name = name;
            Age = age;
            Breed = breed;
        }

        public virtual void Adopt()
        {
            Console.WriteLine($"{Name} has been adopted!");
        }
    }
}
