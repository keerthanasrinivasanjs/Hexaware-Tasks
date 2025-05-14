using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Entity
{
    internal class CarLoans:Loan
    {
        public string CarModel {get;set;}
        public int CarValue { get;set;}

        public CarLoans()
        {

        }
        public CarLoans(int loanId, Customer customer, decimal principalAmount, decimal interestRate, int loanTerm, string loanType, string loanStatus,
                      string carModel, int carValue)
           : base(loanId, customer, principalAmount, interestRate, loanTerm, loanType, loanStatus)
        {
            CarModel = carModel;
            CarValue = carValue;

        }
        public override string ToString()
        {
            return base.ToString() + $", Car Model: {CarModel}, Car Value: {CarValue}";
        }
    }
    }

