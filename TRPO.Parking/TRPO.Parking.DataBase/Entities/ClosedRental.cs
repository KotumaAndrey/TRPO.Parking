﻿using System;
using TRPO.Parking.DataBase.EntityInterfaces;

namespace TRPO.Parking.DataBase.Entities
{
    public class ClosedRental : IEntityWithIntId
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int ParkingSpaceId { get; set; }
        public virtual ParkingSpace ParkingSpace { get; set; }

        public DateTime OpenDate { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public DateTime RealCloseDate { get; set; }
        public double Price { get; set; }
    }
}
