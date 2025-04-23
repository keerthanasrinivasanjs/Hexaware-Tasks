using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techshopapp;

namespace techshopapp
{
    class Customer
    {
        private static int idCounter = 1;
        private int customerID;
        private string firstName, lastName, email, phone, address;
        private int totalOrders = 0;

        public int CustomerID => customerID;
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }

        public Customer(string fname, string lname, string mail, string ph, string addr)
        {
            customerID = idCounter++;
            FirstName = fname;
            LastName = lname;
            Email = mail;
            Phone = ph;
            Address = addr;
        }

        public string GetCustomerDetails()
        {
            return $"Customer ID: {CustomerID}\nName: {FirstName} {LastName}\nEmail: {Email}\nPhone: {Phone}\nAddress: {Address}\nOrders Placed: {totalOrders}";
        }

        public void IncrementOrders() => totalOrders++;
    }
}
