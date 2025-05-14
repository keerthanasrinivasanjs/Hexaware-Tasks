using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Entity
{
    public class Loan
    {
        public int LoanID {  get; set; }
        public Customer Customer { get; set; }
        public decimal PrincipalAmount {  get; set; }
        public decimal InterestRate {  get; set; }
        public int LoanTerm {  get; set; }
        public string LoanType {  get; set; }
        public string LoanStatus {  get; set; }

        public Loan()
        {

        }
        public Loan(int loanID, Customer customer, decimal principalAmount, decimal interestRate, int loanTerm, string loanType, string loanStatus)
        {
            LoanID = loanID;
            Customer = customer;
            PrincipalAmount = principalAmount;
            InterestRate = interestRate;
            LoanTerm = loanTerm;
            LoanType = loanType;
            LoanStatus = loanStatus;
        }
        public override string ToString()
        {
            return $"Loan ID: {LoanID}, Customer: {Customer?.Name}, Amount: {PrincipalAmount}, Interest Rate: {InterestRate}%, Term: {LoanTerm} months, Type: {LoanType}, Status: {LoanStatus}";
            
        }
    }
}
