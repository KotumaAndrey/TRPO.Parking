namespace TRPO.Parking.Entities
{
    public class ClosedRentalParkingSpaces
    {
        public virtual ClosedRental ClosedRental { get; set; }
        public virtual ParkingSpace ParkingSpace { get; set; }
    }
}
