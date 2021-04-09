using System;
using TRPO.Parking.DataBase.EnumEntities;

namespace TRPO.Parking.DataBase.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        
        public Primitives.Gender GenderId { get; set; }
        public virtual GenderEntity Gender { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Experience { get; set; }

        public Primitives.ClientType ClientTypeId { get; set; }
        public virtual ClientTypeEntity ClientType { get; set; }
        
        public DateTime LatePaymentTimeLeft { get; set; }
        public double LatePaymentPriceMultiplier { get; set; }
    }
}
