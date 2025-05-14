using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Exceptions
{
    internal class InvalidLoanException:Exception
    {
        public InvalidLoanException() : base("Invalid loan ID. Loan not found.") { }

        public InvalidLoanException(string message) : base(message) { }
    }
}
