namespace TRPO.Parking.Entities
{
    public class LatePayment
    {
        public int Id { get; set; }
        public virtual Client Client { get; set; }
        public virtual LatePaymentType LatePaymentType { get; set; }
        public virtual ParkingSpace ParkingSpace { get; set; }
        public virtual ActiveRental ActiveRental { get; set; }
        public virtual ClosedRental ClosedRental { get; set; }
    }
}
