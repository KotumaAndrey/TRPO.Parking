namespace TRPO.Parking.DataBase.Entities
{
    public class LatePaymentParkingSpaces
    {
        public int LatePaymentId { get; set; }
        public LatePayment LatePayment { get; set; }

        public int ParkingSpaceId { get; set; }
        public ParkingSpace ParkingSpace { get; set; }
    }
}
