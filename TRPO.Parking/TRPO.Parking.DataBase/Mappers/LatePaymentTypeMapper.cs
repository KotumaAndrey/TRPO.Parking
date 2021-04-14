using System;

using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class LatePaymentTypeMapper
    {
        public static readonly Func<LE.LatePaymentType, DB.LatePaymentType> ToDb =
            latePaymentType => new DB.LatePaymentType
            {
                Id = latePaymentType.Id,
                PriceMultiplier = latePaymentType.PriceMultiplier,
                From = latePaymentType.From,
                To = latePaymentType.To
            };

        public static readonly Func<DB.LatePaymentType, LE.LatePaymentType> ToLogic =
            latePaymentType => new LE.LatePaymentType
            {
                Id = latePaymentType.Id,
                PriceMultiplier = latePaymentType.PriceMultiplier,
                From = latePaymentType.From,
                To = latePaymentType.To
            };
    }
}
