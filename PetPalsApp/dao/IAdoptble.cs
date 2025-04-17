using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.dao
{
    public interface IAdoptable
    {
        string Name { get; } 
        void Adopt();
    }
}
