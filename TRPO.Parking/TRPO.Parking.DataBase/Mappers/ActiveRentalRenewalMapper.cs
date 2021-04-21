using System;
using TRPO.Parking.DataBase.Mappers.Utilities;
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
                Rental = ActiveRentalMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.ActiveRental, DB.ActiveRental>
                    (activeRentalRenewal.RentalId)),
                NewEndDate = activeRentalRenewal.NewEndDate,
                Type = RentalRenewalTypeMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.RentalRenewalType, DB.RentalRenewalType>
                    (activeRentalRenewal.TypeId))
            };
    }
}
