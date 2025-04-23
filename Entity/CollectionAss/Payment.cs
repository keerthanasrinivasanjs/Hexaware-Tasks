using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss
{
    internal class Payment
    {
            public int PaymentID { get; set; }
            public int OrderID { get; set; }
            public decimal Amount { get; set; }
            public string PaymentMethod { get; set; } // e.g., Card, UPI, NetBanking
            public string Status { get; set; } // e.g., Paid, Failed, Pending
            public DateTime PaymentDate { get; set; }

            public override string ToString()
            {
                return $"PaymentID: {PaymentID}, OrderID: {OrderID}, Amount: {Amount:C}, Method: {PaymentMethod}, Status: {Status}, Date: {PaymentDate}";
            }
        }
    }


