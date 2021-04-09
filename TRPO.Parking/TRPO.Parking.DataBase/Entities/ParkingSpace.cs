using TRPO.Parking.DataBase.EnumEntities;

namespace TRPO.Parking.DataBase.Entities
{
    public class ParkingSpace
    {
        public int Id { get; set; }

        public int FloorId { get; set; }
        public virtual Floor Floor { get; set; }

        public int Row { get; set; }
        public int Colunm { get; set; }

        public Primitives.ParkingSpaceStatus StatusId { get; set; }
        public virtual ParkingSpaceStatusEntity Status { get; set; }
    }
}
