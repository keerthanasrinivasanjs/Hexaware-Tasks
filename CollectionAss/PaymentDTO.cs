using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss
{
    internal class PaymentDTO
    {
       
            public int PaymentID { get; set; }
            public int OrderID { get; set; }
            public decimal Amount { get; set; }
            public string Status { get; set; }

            public override string ToString()
            {
                return $"PaymentID: {PaymentID}, OrderID: {OrderID}, Amount: {Amount:C}, Status: {Status}";
            }
        }
    }




