using System;

namespace TRPO.Parking.DataBase.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        
        public int GenderEntityId { get; set; }
        public GenderEntity GenderEntity { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Experience { get; set; }

        public int ClientTypeEntityId { get; set; }
        public ClientTypeEntity ClientTypeEntity { get; set; }
        
        public DateTime LatePaymentTimeLeft { get; set; }
        public double LatePaymentPriceMultiplier { get; set; }
    }
}
