﻿using TRPO.Parking.Entities.Primitives;

namespace TRPO.Parking.Entities
{
#nullable enable
    public class Client 
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public virtual Gender? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? Experience { get; set; }
        public virtual ClientType ClientType { get; set; }
        public int LatePaymentMinutesLeft { get; set; }
        public double LatePaymentPriceMultiplier { get; set; }
    }
}