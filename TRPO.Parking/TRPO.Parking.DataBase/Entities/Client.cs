using TRPO.Parking.DataBase.EntityInterfaces;
using TRPO.Parking.DataBase.EnumEntities;
using TRPO.Parking.Entities.Primitives;

namespace TRPO.Parking.DataBase.Entities
{
#nullable enable
    public class Client : IEntityWithIntId
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
        public int? Age { get; set; }
        
        public Gender? GenderId { get; set; }
        public virtual GenderEntity? Gender { get; set; }

        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? Experience { get; set; }

        public ClientType ClientTypeId { get; set; }
        public virtual ClientTypeEntity ClientType { get; set; }
        
        public int LatePaymentMinutesLeft { get; set; }
        public double LatePaymentPriceMultiplier { get; set; }
    }
}
