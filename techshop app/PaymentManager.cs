using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techshop_app
{
    internal class PaymentManager
    {
      
            private List<Payment> payments = new List<Payment>();

            public void RecordPayment(int orderId, decimal amount)
            {
                Payment payment = new Payment { OrderId = orderId, Amount = amount, Status = "Paid" };
                payments.Add(payment);
                Console.WriteLine("Payment recorded.");
            }

            public List<Payment> GetAllPayments()
            {
                return payments;
            }
        }
    }

