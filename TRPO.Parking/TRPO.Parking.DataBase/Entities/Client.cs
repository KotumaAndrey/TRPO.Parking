using System;

namespace TRPO.Parking.DataBase.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int GenderId { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Experience { get; set; }

        public int ClientTypeId { get; set; }

        public DateTime LatePaymentTimeLeft { get; set; }

        public double PriceMultiplier { get; set; }
    }
}
