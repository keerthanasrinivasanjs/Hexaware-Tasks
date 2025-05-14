using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagement.Entity;
using Microsoft.Data.SqlClient;

namespace LoanManagement.dao
{
    interface ILoanRepository
    {
        void ApplyLoan(Loan loan); 
        double CalculateInterest(int loanId);
        double CalculateInterest(double principal, double rate, int term); 

        void LoanStatus(int loanId); 

        double CalculateEMI(int loanId); 
        double CalculateEMI(double principal, double rate, int term);

        void LoanRepayment(int loanId, double amount);

        List<Loan> GetAllLoans();

        Loan GetLoanById(int loanId);
    }
}

    
