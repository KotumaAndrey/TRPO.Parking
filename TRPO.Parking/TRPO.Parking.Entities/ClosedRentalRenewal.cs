using System;

namespace TRPO.Parking.Entities
{
    public class ClosedRentalRenewal
    {
        public int Id { get; set; }
        public virtual ClosedRental Rental { get; set; }
        public DateTime OldEndDate { get; set; }
        public DateTime NewEndDate { get; set; }
        public virtual RentalRenewalType Type { get; set; }
    }
}
