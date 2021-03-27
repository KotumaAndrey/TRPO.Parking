namespace TRPO.Parking.DataBase.Entities
{
    public class ActiveRentalParkingSpaces
    {
        public int ActiveRentalId { get; set; }
        public ActiveRental ActiveRental { get; set; }

        public int ParkingSpaceId { get; set; }
        public ParkingSpace ParkingSpace { get; set; }
    }
}
