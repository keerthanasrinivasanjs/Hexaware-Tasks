using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlling
{
    internal class IncompleteOrderException : Exception
    {
        public IncompleteOrderException(string message) : base(message)
        {
        }
    }
}
