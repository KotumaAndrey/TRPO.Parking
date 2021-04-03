using RequestType = TRPO.Parking.DataBase.Primitives.ClientTypeUpdateRequestStatus;

namespace TRPO.Parking.DataBase.EnumEntities
{
    public class ClientTypeUpdateRequestStatusEntity : BaseEnumEntity<RequestType>
    {
        public ClientTypeUpdateRequestStatusEntity() : base() { }

        public ClientTypeUpdateRequestStatusEntity(RequestType value) : base(value) { }
    }
}
