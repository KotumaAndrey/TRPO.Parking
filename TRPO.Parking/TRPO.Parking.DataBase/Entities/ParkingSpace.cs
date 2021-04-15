using TRPO.Parking.DataBase.EntityInterfaces;
using TRPO.Parking.DataBase.EnumEntities;
using TRPO.Parking.Entities.Primitives;

namespace TRPO.Parking.DataBase.Entities
{
    public class ParkingSpace : IEntityWithIntId
    {
        public int Id { get; set; }

        public int FloorId { get; set; }
        public virtual Floor Floor { get; set; }

        public int Row { get; set; }
        public int Colunm { get; set; }

        public ParkingSpaceStatus StatusId { get; set; }
        public virtual ParkingSpaceStatusEntity Status { get; set; }
    }
}
