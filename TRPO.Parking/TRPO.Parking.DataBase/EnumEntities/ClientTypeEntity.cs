using ClientType = TRPO.Parking.Entities.Primitives.ClientType;

namespace TRPO.Parking.DataBase.EnumEntities
{
    public class ClientTypeEntity : BaseEnumEntity<ClientType>
    {
        public ClientTypeEntity() : base() { }
        
        public ClientTypeEntity(ClientType value, double price) : base(value)
        {
            Price = price;
        }

        public double Price { get; set; }
    }
}
