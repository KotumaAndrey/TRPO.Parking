using Status = TRPO.Parking.DataBase.Primitives.ParkingSpaceStatus;

namespace TRPO.Parking.DataBase.EnumEntities
{
    public class ParkingSpaceStatusEntity : BaseEnumEntity<Status>
    {
        public ParkingSpaceStatusEntity() : base() { }

        public ParkingSpaceStatusEntity(Status value) : base(value) { }
    }
}
