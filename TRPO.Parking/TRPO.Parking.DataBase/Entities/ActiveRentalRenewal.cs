﻿using System;
using TRPO.Parking.DataBase.EntityInterfaces;

namespace TRPO.Parking.DataBase.Entities
{
    public class ActiveRentalRenewal : IEntityWithIntId
    {
        public int Id { get; set; }

        public int RentalId { get; set; }
        public virtual ActiveRental Rental { get; set; }

        public DateTime OldEndDate { get; set; }
        public DateTime NewEndDate { get; set; }

        public int TypeId { get; set; }
        public virtual RentalRenewalType Type { get; set; }
    }
}
