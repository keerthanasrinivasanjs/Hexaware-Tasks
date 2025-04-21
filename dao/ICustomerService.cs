
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarConnectApp.Entity;

namespace CarConnect.dao
{
    interface ICustomerService
    {
        Customer GetCustomerById(int id);
        Customer GetCustomerByUsername(string username);
        void RegisterCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}