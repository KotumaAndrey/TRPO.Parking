namespace TRPO.Parking.DataBase.Entities
{
    public class ClosedRentalParkingSpaces
    {
        public int ClosedRentalId { get; set; }
        public virtual ClosedRental ClosedRental { get; set; }

        public int ParkingSpaceId { get; set; }
        public virtual ParkingSpace ParkingSpace { get; set; }
    }
}
