namespace TRPO.Parking.Entities
{
    class LatePayment
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int LatePaymentTypeId { get; set; }

        public int ParkingSpace { get; set; }

        public int RequestId { get; set; }
    }
}
