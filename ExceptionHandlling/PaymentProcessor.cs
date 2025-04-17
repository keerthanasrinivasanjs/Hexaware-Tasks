using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlling
{
    internal class PaymentProcessor
    {
        public void ProcessPayment(Order order)
        {
            try
            {
               
                bool paymentDeclined = false;
                if (paymentDeclined)
                {
                    throw new PaymentFailedException("Payment was declined. Please try again.");
                }
            }
            catch (PaymentFailedException e)
            {
                HandlePaymentFailure(e);
            }
        }

        private void HandlePaymentFailure(PaymentFailedException exception)
        {
      
            Console.WriteLine(exception.Message);
        }
    }
}

