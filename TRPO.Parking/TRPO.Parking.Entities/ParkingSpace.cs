using TRPO.Parking.Entities.Primitives;

namespace TRPO.Parking.Entities
{
    public class ParkingSpace
    {
        public int Id { get; set; }
        public virtual Floor Floor { get; set; }
        public int Row { get; set; }
        public int Colunm { get; set; }
        public virtual ParkingSpaceStatus Status { get; set; }
    }
}
