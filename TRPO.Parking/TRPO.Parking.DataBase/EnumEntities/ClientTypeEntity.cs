using ClientType = TRPO.Parking.DataBase.Primitives.ClientType;

namespace TRPO.Parking.DataBase.EnumEntities
{
    public class ClientTypeEntity : BaseEnumEntity<ClientType>
    {
        public ClientTypeEntity() : base() { }

        public ClientTypeEntity(ClientType value, double priceMultipler) : base(value)
        {
            PriceMultipler = priceMultipler;
        }

        public double PriceMultipler { get; set; }
    }
}
