﻿namespace TRPO.Parking.DataBase.Entities
{
    public class ClientTypeEntity
    {
        public Primitives.ClientType Id { get; set; }
        public string Title { get; set; }
        public double PriceMultipler { get; set; }
    }
}