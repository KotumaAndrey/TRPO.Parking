﻿using System;

namespace TRPO.Parking.DataBase.Entities
{
    public class ClosedRental
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ParkingSpaceId { get; set; }
        public ParkingSpace ParkingSpace { get; set; }

        public DateTime OpenDate { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public DateTime RealCloseDate { get; set; }
        public double Price { get; set; }
    }
}