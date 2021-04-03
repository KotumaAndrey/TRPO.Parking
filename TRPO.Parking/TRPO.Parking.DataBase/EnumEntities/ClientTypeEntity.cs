using ClientType = TRPO.Parking.DataBase.Primitives.ClientType;

namespace TRPO.Parking.DataBase.EnumEntities
{
    public class ClientTypeEntity : BaseEnumEntity<ClientType>
    {
        public ClientTypeEntity() : base() { }

        // TODO: Убрать заглушку priceMultipler
        public ClientTypeEntity(ClientType value, double priceMultipler = 1) : base(value)
        {
            PriceMultipler = priceMultipler;
        }

        public double PriceMultipler { get; set; }
    }
}
