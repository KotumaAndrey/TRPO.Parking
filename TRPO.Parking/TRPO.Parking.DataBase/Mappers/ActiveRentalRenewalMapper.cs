using System;

using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class ActiveRentalRenewalMapper
    {
        public static readonly Func<LE.ActiveRentalRenewal, DB.ActiveRentalRenewal> ToDb =
            activeRentalRenewal => new DB.ActiveRentalRenewal
            {
                Id = activeRentalRenewal.Id,
                RentalId = activeRentalRenewal.Rental.Id,
                //Rental = ActiveRentalMapper.ToDb(activeRentalRenewal.Rental),
                OldEndDate = activeRentalRenewal.Rental.ExpectedCloseDate,
                NewEndDate = activeRentalRenewal.NewEndDate,
                TypeId = activeRentalRenewal.Type.Id,
                //Type = RentalRenewalTypeMapper.ToDb(activeRentalRenewal.Type)
            };

        public static readonly Func<DB.ActiveRentalRenewal, LE.ActiveRentalRenewal> ToLogic =
            activeRentalRenewal => new LE.ActiveRentalRenewal
            {
                Id = activeRentalRenewal.Id,
                Rental = ActiveRentalMapper.ToLogic(activeRentalRenewal.Rental),
                NewEndDate = activeRentalRenewal.NewEndDate,
                Type = RentalRenewalTypeMapper.ToLogic(activeRentalRenewal.Type)
            };
    }
}
