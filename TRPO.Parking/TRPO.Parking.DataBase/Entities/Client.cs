﻿using System;

namespace TRPO.Parking.DataBase.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Primitives.Gender GenderId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Experience { get; set; }
        public Primitives.ClientType ClientTypeId { get; set; }
        public DateTime LatePaymentTimeLeft { get; set; }
        public double LatePaymentPriceMultiplier { get; set; }
    }
}
