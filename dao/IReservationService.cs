using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarConnectApp.Entity;

namespace CarConnectApp.dao
{
    interface  IReservationService
    {
        Reservation GetReservationById(int id);
        List<Reservation> GetReservationsByCustomerId(int customerId);
        void CreateReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void CancelReservation(int reservationId);
    }
}
