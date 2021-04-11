using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class RentalRenewalTypeMapper
    {
        public static readonly Func<LE.RentalRenewalType, DB.RentalRenewalType>  ToDb = 
            rentalRenewalType => new DB.RentalRenewalType
            {
                Id = rentalRenewalType.Id,
                Title = rentalRenewalType.Title,
                PriceMultiplier = rentalRenewalType.PriceMultiplier,
                From = rentalRenewalType.From,
                To = rentalRenewalType.To
            };

        public static readonly Func<DB.RentalRenewalType, LE.RentalRenewalType> ToLogic = 
            rentalRenewalType => new LE.RentalRenewalType
            {
                Id = rentalRenewalType.Id,
                Title = rentalRenewalType.Title,
                PriceMultiplier = rentalRenewalType.PriceMultiplier,
                From = rentalRenewalType.From,
                To = rentalRenewalType.To
            };
    }
}
