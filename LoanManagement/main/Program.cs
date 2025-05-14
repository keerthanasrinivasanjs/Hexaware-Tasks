using LoanManagement.Entity;
using LoanManagement.dao;
using LoanManagement.Exceptions;
using LoanManagementSystem.dao;

namespace LoanManagement
{
    internal class Program
    {
       
            static void Main(string[] args)
            {
                LoanService loanService = new LoanService();
                Customer customer = new Customer();

                // Sample menu-driven program for Loan Management System
                while (true)
                {
                    Console.WriteLine("\n------------------- Loan Management System -------------------");
                    Console.WriteLine("1. Apply for Loan");
                    Console.WriteLine("2. View All Loans");
                    Console.WriteLine("3. View Loan by ID");
                    Console.WriteLine("4. Calculate EMI");
                    Console.WriteLine("5. Calculate Interest");
                    Console.WriteLine("6. Loan Repayment");
                    Console.WriteLine("7. Exit");
                    Console.Write("Enter your choice: ");

                    try
                    {
                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                ApplyLoan(loanService);
                                break;
                            case 2:
                                loanService.GetAllLoans();
                                break;
                            case 3:
                                ViewLoanById(loanService);
                                break;
                            case 4:
                                CalculateEMI(loanService);
                                break;
                            case 5:
                                CalculateInterest(loanService);
                                break;
                            case 6:
                                LoanRepayment(loanService);
                                break;
                            case 7:
                                Console.WriteLine("Exiting the Loan Management System.");
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
            }

            // Method to apply for a loan
            static void ApplyLoan(LoanService loanService)
            {
                try
                {
                    Loan loan = new Loan();
                    Console.WriteLine("\nEnter loan details:");

                    // Get loan details from user input
                    Console.Write("Enter Loan ID: ");
                    loan.LoanID = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Customer ID: ");
                    loan.Customer.CustomerID = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Principal Amount: ");
                    loan.PrincipalAmount = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Enter Interest Rate (in percentage): ");
                    loan.InterestRate = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Enter Loan Term (in months): ");
                    loan.LoanTerm = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Loan Type (Personal/Home/Car): ");
                    loan.LoanType = Enum.Parse(typeof(LoanType), Console.ReadLine(), true).ToString();

                // Apply loan
                bool result = loanService.ApplyLoan(loan);
                    if (result)
                    {
                        Console.WriteLine("Loan application successful.");
                    }
                    else
                    {
                        Console.WriteLine("Loan application failed.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while applying for loan: " + ex.Message);
                }
            }

            // Method to view a loan by ID
            static void ViewLoanById(LoanService loanService)
            {
                try
                {
                    Console.Write("Enter Loan ID to view details: ");
                    int loanId = Convert.ToInt32(Console.ReadLine());
                    loanService.GetLoanById(loanId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving loan: " + ex.Message);
                }
            }

            // Method to calculate EMI for a loan
            static void CalculateEMI(LoanService loanService)
            {
                try
                {
                    Console.Write("Enter Loan ID to calculate EMI: ");
                    int loanId = Convert.ToInt32(Console.ReadLine());
                    double emi = loanService.CalculateEMI(loanId);
                    Console.WriteLine($"The calculated EMI for Loan ID {loanId} is: {emi}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error calculating EMI: " + ex.Message);
                }
            }

            // Method to calculate interest for a loan
            static void CalculateInterest(LoanService loanService)
            {
                try
                {
                    Console.Write("Enter Loan ID to calculate interest: ");
                    int loanId = Convert.ToInt32(Console.ReadLine());
                    decimal interest = (decimal)loanService.CalculateInterest(loanId);
                    Console.WriteLine($"The calculated interest for Loan ID {loanId} is: {interest}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error calculating interest: " + ex.Message);
                }
            }

            // Method for loan repayment
            static void LoanRepayment(LoanService loanService)
            {
                try
                {
                    Console.Write("Enter Loan ID for repayment: ");
                    int loanId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter repayment amount: ");
                    decimal amount = (decimal)Convert.ToDouble(Console.ReadLine());

                    loanService.LoanRepayment(loanId, (double)amount);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error during loan repayment: " + ex.Message);
                }
            }
        }

    internal class LoanType
    {
    }
}
