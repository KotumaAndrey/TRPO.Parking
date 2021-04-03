using System;

namespace TRPO.Parking.DataBase.Entities
{
    public class ClosedRentalRenewal
    {
        public int Id { get; set; }

        public int RentalId { get; set; }
        public virtual ClosedRental Rental { get; set; }

        public DateTime OldEndDate { get; set; }
        public DateTime NewEndDate { get; set; }

        public int TypeId { get; set; }
        public virtual RentalRenewalType Type { get; set; }
    }
}
