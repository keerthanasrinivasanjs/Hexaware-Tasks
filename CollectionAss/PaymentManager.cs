using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss
{
    internal class PaymentManager
    {
        private List<Payment> payments = new List<Payment>();

        public void AddPayment(Payment payment)
        {
            if (payments.Exists(p => p.PaymentID == payment.PaymentID))
            {
                throw new Exception("Payment with this ID already exists.");
            }
            payments.Add(payment);
        }

        public void UpdatePaymentStatus(int paymentId, string newStatus)
        {
            Payment payment = payments.Find(p => p.PaymentID == paymentId);
            if (payment == null)
            {
                throw new Exception("Payment not found.");
            }
            payment.Status = newStatus;
        }

        public List<Payment> GetPaymentsByOrderID(int orderId)
        {
            return payments.FindAll(p => p.OrderID == orderId);
        }

        public void DisplayAllPayments()
        {
            foreach (var payment in payments)
            {
                Console.WriteLine(payment.ToString());
            }
        }
    }
}


    

