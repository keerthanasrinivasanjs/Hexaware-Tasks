using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PetPalsApp.Util
{
    public static class DBPropertyUtil
    {
        public static string GetConnectionString()
        {
            
            return "Data Source=DESKTOP-0GIN3MJ;Initial Catalog=PetPalsDB;Integrated Security=True";
        }
    }
}