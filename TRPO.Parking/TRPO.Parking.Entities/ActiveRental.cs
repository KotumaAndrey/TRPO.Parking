using System;

namespace TRPO.Parking.DataBase.Entities
{
    public class ActiveRental
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ParkingSpaceId { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime ExpectedCloseDate { get; set; }
    }
}
