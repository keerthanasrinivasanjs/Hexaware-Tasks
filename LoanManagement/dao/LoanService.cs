using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
 using LoanManagement.Entity;
 using LoanManagement.Exceptions;
using LoanManagement.util;
using LoanManagementSystem.dao;


namespace LoanManagementSystem.dao
    {
        public class LoanService : ILoanRepository
        {
            // Apply a loan
            public bool ApplyLoan(Loan loan)
            {
                try
                {
                // Get the connection from DBConnUtil
                using (SqlConnection conn = DBConnUtil.GetDBConn())
                {
                        // Ask for confirmation to apply the loan
                        Console.WriteLine("Do you confirm the loan application (Yes/No)?");
                        string confirmation = Console.ReadLine();

                        if (confirmation.ToLower() == "yes")
                        {
                            string query = "INSERT INTO Loans (LoanId, CustomerId, PrincipalAmount, InterestRate, LoanTerm, LoanType, LoanStatus) VALUES (@LoanId, @CustomerId, @PrincipalAmount, @InterestRate, @LoanTerm, @LoanType, @LoanStatus)";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@LoanId", loan.LoanID);
                                cmd.Parameters.AddWithValue("@CustomerId", loan.Customer.CustomerID);
                                cmd.Parameters.AddWithValue("@PrincipalAmount", loan.PrincipalAmount);
                                cmd.Parameters.AddWithValue("@InterestRate", loan.InterestRate);
                                cmd.Parameters.AddWithValue("@LoanTerm", loan.LoanTerm);
                                cmd.Parameters.AddWithValue("@LoanType", loan.LoanType.ToString());
                                cmd.Parameters.AddWithValue("@LoanStatus", "Pending");

                                int result = cmd.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    Console.WriteLine("Loan application submitted successfully.");
                                    return true;
                                }
                                else
                                {
                                    Console.WriteLine("Failed to apply loan.");
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Loan application cancelled.");
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error applying loan: " + ex.Message);
                }
            }

            // Calculate interest for a loan by loanId
            public double CalculateInterest(int loanId)
            {
                try
                {
                using (SqlConnection conn = DBConnUtil.GetDBConn())
                {
                        string query = "SELECT PrincipalAmount, InterestRate, LoanTerm FROM Loans WHERE LoanId = @LoanId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@LoanId", loanId);
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                double principal = reader.GetDouble(0);
                                double interestRate = reader.GetDouble(1);
                                int loanTerm = reader.GetInt32(2);

                                // Calculate interest using the formula
                                double interest = (principal * interestRate * loanTerm) / 12;
                                return interest;
                            }
                            else
                            {
                                throw new InvalidLoanException("Loan not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error calculating interest: " + ex.Message);
                }
            }

            // Overloaded method to calculate interest while creating the loan
            public double CalculateInterest(double principalAmount, double interestRate, int loanTerm)
            {
                try
                {
                    // Calculate interest using the formula
                    double interest = (principalAmount * interestRate * loanTerm) / 12;
                    return interest;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error calculating interest: " + ex.Message);
                }
            }

            // Update loan status based on the customer's credit score
            public void LoanStatus(int loanId)
            {
                try
                {
                using (SqlConnection conn = DBConnUtil.GetDBConn())
                {
                        string query = "SELECT CreditScore FROM Customers WHERE CustomerId = (SELECT CustomerId FROM Loans WHERE LoanId = @LoanId)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@LoanId", loanId);
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                int creditScore = reader.GetInt32(0);

                                string status = creditScore > 650 ? "Approved" : "Rejected";

                                // Update loan status based on credit score
                                string updateQuery = "UPDATE Loans SET LoanStatus = @LoanStatus WHERE LoanId = @LoanId";
                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@LoanStatus", status);
                                    updateCmd.Parameters.AddWithValue("@LoanId", loanId);

                                    int result = updateCmd.ExecuteNonQuery();

                                    if (result > 0)
                                    {
                                        Console.WriteLine("Loan status updated to: " + status);
                                    }
                                    else
                                    {
                                        throw new InvalidLoanException("Loan status update failed.");
                                    }
                                }
                            }
                            else
                            {
                                throw new InvalidLoanException("Loan not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating loan status: " + ex.Message);
                }
            }

            // Calculate EMI for a loan by loanId
            public double CalculateEMI(int loanId)
            {
                try
                {
                using (SqlConnection conn = DBConnUtil.GetDBConn())
                {
                        string query = "SELECT PrincipalAmount, InterestRate, LoanTerm FROM Loans WHERE LoanId = @LoanId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@LoanId", loanId);
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                double principal = reader.GetDouble(0);
                                double annualRate = reader.GetDouble(1);
                                int loanTerm = reader.GetInt32(2);

                                double monthlyRate = annualRate / 12 / 100;
                                double emi = (principal * monthlyRate * Math.Pow(1 + monthlyRate, loanTerm)) /
                                             (Math.Pow(1 + monthlyRate, loanTerm) - 1);
                                return Math.Round(emi, 2);
                            }
                            else
                            {
                                throw new InvalidLoanException("Loan not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error calculating EMI: " + ex.Message);
                }
            }

            // Overloaded method to calculate EMI with parameters
            public double CalculateEMI(double principal, double annualRate, int loanTerm)
            {
                try
                {
                    double monthlyRate = annualRate / 12 / 100;
                    double emi = (principal * monthlyRate * Math.Pow(1 + monthlyRate, loanTerm)) /
                                 (Math.Pow(1 + monthlyRate, loanTerm) - 1);
                    return Math.Round(emi, 2);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error calculating EMI: " + ex.Message);
                }
            }

            // Loan repayment based on amount paid
            public void LoanRepayment(int loanId, double amount)
            {
                try
                {
                using (SqlConnection conn = DBConnUtil.GetDBConn())
                {
                        string query = "SELECT PrincipalAmount, LoanTerm FROM Loans WHERE LoanId = @LoanId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@LoanId", loanId);
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                double principal = reader.GetDouble(0);
                                int loanTerm = reader.GetInt32(1);

                                // Calculate EMI to check repayment
                                double emi = CalculateEMI(principal, 10, loanTerm); // Assuming 10% interest rate for calculation
                                int numberOfEmis = (int)(amount / emi);

                                if (amount < emi)
                                {
                                    Console.WriteLine("Amount is less than one EMI. Repayment rejected.");
                                }
                                else
                                {
                                    Console.WriteLine("You can repay for " + numberOfEmis + " months.");
                                    // Update loan balance after repayment logic can be added here.
                                }
                            }
                            else
                            {
                                throw new InvalidLoanException("Loan not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error processing loan repayment: " + ex.Message);
                }
            }

            // Retrieve all loans
            public void GetAllLoans()
            {
                try
                {
                using (SqlConnection conn = DBConnUtil.GetDBConn())
                {
                        string query = "SELECT LoanId, CustomerId, PrincipalAmount, LoanTerm, LoanType, LoanStatus FROM Loans";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                Console.WriteLine($"LoanId: {reader.GetInt32(0)}, CustomerId: {reader.GetInt32(1)}, PrincipalAmount: {reader.GetDouble(2)}, LoanTerm: {reader.GetInt32(3)}, LoanType: {reader.GetString(4)}, LoanStatus: {reader.GetString(5)}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving loans: " + ex.Message);
                }
            }

            // Retrieve loan by loanId
            public void GetLoanById(int loanId)
            {
                try
                {
                      using (SqlConnection conn = DBConnUtil.GetDBConn())
                    {
                        string query = "SELECT LoanId, CustomerId, PrincipalAmount, LoanTerm, LoanType, LoanStatus FROM Loans WHERE LoanId = @LoanId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@LoanId", loanId);
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                Console.WriteLine($"LoanId: {reader.GetInt32(0)}, CustomerId: {reader.GetInt32(1)}, PrincipalAmount: {reader.GetDouble(2)}, LoanTerm: {reader.GetInt32(3)}, LoanType: {reader.GetString(4)}, LoanStatus: {reader.GetString(5)}");
                            }
                            else
                            {
                                throw new InvalidLoanException("Loan not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving loan by ID: " + ex.Message);
                }
            }
        }
    }
