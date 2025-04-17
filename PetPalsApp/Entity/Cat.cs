using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.Entity
{
    public class Cat : Pet
    {
        public string Color { get; set; }

        public Cat(string name, int age, string breed, string color): base(name, age, breed)
        {
            Color = color;
        }
    }
}

