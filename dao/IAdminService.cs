using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarConnectApp.Entity;

namespace CarConnectApp.dao
{
    interface IAdminService
    {
        Admin GetAdminById(int id);
        Admin GetAdminByUsername(string username);
        void RegisterAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(int id);
    }
}
