namespace TRPO.Parking.DataBase.Entities
{
    public class ParkingSpace
    {
        public int Id { get; set; }

        public int FloorId { get; set; }
        public Floor Floor { get; set; }

        public int Row { get; set; }
        public int Colunm { get; set; }

        public int StatusId { get; set; }
        public ParkingSpaceStatusEntity Status { get; set; }
    }
}
