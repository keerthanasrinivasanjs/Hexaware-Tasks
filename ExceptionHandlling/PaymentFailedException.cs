﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlling
{
    internal class PaymentFailedException:Exception
    {
        public PaymentFailedException(string message) : base(message)
        {
        }
    }
}
