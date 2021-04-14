using System;

namespace TRPO.Parking.Entities
{
    public class ActiveRentalRenewal
    {
        public int Id { get; set; }
        public virtual ActiveRental Rental { get; set; }
        public  DateTime NewEndDate { get; set; }
        public virtual RentalRenewalType Type { get; set; }
    }
}
