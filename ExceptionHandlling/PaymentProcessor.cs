using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlling
{
    internal class PaymentProcessor
    {
        public void ProcessPayment(OrderUpdater order)
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

        internal void ProcessPayment(Order order)
        {
            throw new NotImplementedException();
        }

        private void HandlePaymentFailure(PaymentFailedException exception)
        {
      
            Console.WriteLine(exception.Message);
        }
    }
}

