using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlling
{
    internal class FileIOException : Exception
    {
        public FileIOException(string message, IOException e) : base(message)
        {
        }
    }
}
