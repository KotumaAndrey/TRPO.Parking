namespace TRPO.Parking.DataBase.Entities
{
    public class LatePayment
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int LatePaymentTypeId { get; set; }
        public LatePaymentType LatePaymentType { get; set; }

        public int ParkingSpaceId { get; set; }
        public ParkingSpace ParkingSpace { get; set; }

        public int? ClosedRentalId { get; set; }
        public ClosedRental ClosedRental { get; set; }
    }
}
