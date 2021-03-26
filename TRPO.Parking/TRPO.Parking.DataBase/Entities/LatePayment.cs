namespace TRPO.Parking.DataBase.Entities
{
    public class LatePayment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int LatePaymentTypeId { get; set; }
        public int ParkingSpaceId { get; set; }
        public int? RequestId { get; set; }
    }
}
