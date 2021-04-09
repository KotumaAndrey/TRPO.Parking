namespace TRPO.Parking.DataBase.Entities
{
    public class ActiveRentalParkingSpaces
    {
        public int ActiveRentalId { get; set; }
        public virtual ActiveRental ActiveRental { get; set; }

        public int ParkingSpaceId { get; set; }
        public virtual ParkingSpace ParkingSpace { get; set; }
    }
}
