using TRPO.Parking.DataBase.EntityInterfaces;

namespace TRPO.Parking.DataBase.Entities
{
    public class RentalRenewalType : IEntityWithIntId
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double PriceMultiplier { get; set; }
        public int? From { get; set; }
        public int To { get; set; }
    }
}
