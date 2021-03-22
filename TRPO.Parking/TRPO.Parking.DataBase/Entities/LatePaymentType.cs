namespace TRPO.Parking.DataBase.Entities
{
    public class LatePaymentType
    {
        public int Id { get; set; }

        public int From { get; set; }

        public int? To { get; set; }

        public double PriceMultiplier { get; set; }
    }
}
