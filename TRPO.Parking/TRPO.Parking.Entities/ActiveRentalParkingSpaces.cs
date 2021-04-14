namespace TRPO.Parking.Entities
{
    public class ActiveRentalParkingSpaces
    {
        public virtual ActiveRental ActiveRental { get; set; }
        public virtual ParkingSpace ParkingSpace { get; set; }
    }
}
