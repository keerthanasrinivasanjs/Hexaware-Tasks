using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.Entity
{
    public class CashDonation : Donation
    {
        public DateTime DonationDate { get; set; }

        public CashDonation(string donorName, decimal amount, DateTime date)
            : base(donorName, amount)
        {
            DonationDate = date;
        }

        public override void RecordDonation()
        {
            Console.WriteLine($"Cash Donation Recorded: {DonorName} donated ${Amount} on {DonationDate.ToShortDateString()}");
        }
    }
}