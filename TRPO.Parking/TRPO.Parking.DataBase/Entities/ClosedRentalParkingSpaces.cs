namespace TRPO.Parking.DataBase.Entities
{
    public class ClosedRentalParkingSpaces
    {
        public int ClosedRentalId { get; set; }
        public ClosedRental ClosedRental { get; set; }

        public int ParkingSpaceId { get; set; }
        public ParkingSpace ParkingSpace { get; set; }
    }
}
