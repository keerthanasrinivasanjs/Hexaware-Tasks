using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.exception
{
    public class InvalidPetAgeException : Exception
    {
        public InvalidPetAgeException(string message) : base(message) { }
    }
}

