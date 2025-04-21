using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarConnect;

namespace CarConnectApp.dao
{
    public interface IVehicleService
    {
        Vehicle GetVehicleById(int id);
        List<Vehicle> GetAvailableVehicles();
        bool AddVehicle(Vehicle vehicle);
        bool UpdateVehicle(Vehicle vehicle);
        void RemoveVehicle(int id);
    }
}