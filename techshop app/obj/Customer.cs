using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techshop_app
{
    internal class Customer
    {
        private int customerID;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;
        private int totalOrders; 
        public Customer(int customerID, string firstName, string lastName, string email, string phone, string address)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.totalOrders = 0; 
        }

    
        public int CustomerID => customerID;
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }


        public int CalculateTotalOrders() => totalOrders;
        public void UpdateTotalOrders() => totalOrders++;
        public string GetCustomerDetails()
        {
            return $"{customerID}: {firstName} {lastName}, Email: {email}, Phone: {phone}, Address: {address}";
        }
    }
}

