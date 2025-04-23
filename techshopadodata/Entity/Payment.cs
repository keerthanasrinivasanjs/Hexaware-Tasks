using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techshopadodata.Entity
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
