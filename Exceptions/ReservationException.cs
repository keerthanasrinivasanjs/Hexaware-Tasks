using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnectApp.Exceptions
{
    class ReservationException : Exception
    {
        public ReservationException(string message) : base(message) { }

    }

}


