using System;

namespace TRPO.Parking.Entities
{
    public class ClosedRental
    {
        public int Id { get; set; }
        public virtual Client Client { get; set; }
        public virtual ParkingSpace ParkingSpace { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public DateTime RealCloseDate { get; set; }
        public double Price { get; set; }
    }
}
