using System;

namespace TRPO.Parking.Entities
{
    public class ActiveRental
    {
        public int Id { get; set; }
        public virtual Client Client { get; set; }
        public virtual ParkingSpace ParkingSpace { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
    }
}
