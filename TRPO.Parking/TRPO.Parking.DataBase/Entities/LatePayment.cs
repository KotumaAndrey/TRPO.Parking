using TRPO.Parking.DataBase.EntityInterfaces;

namespace TRPO.Parking.DataBase.Entities
{
    public class LatePayment : IEntityWithIntId
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int LatePaymentTypeId { get; set; }
        public virtual LatePaymentType LatePaymentType { get; set; }

        public int ParkingSpaceId { get; set; }
        public virtual ParkingSpace ParkingSpace { get; set; }

        public int? ActiveRentalId { get; set; }
        public virtual ActiveRental ActiveRental { get; set; }

        public int? ClosedRentalId { get; set; }
        public virtual ClosedRental ClosedRental { get; set; }
    }
}
