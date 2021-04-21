﻿using System;
using TRPO.Parking.DataBase.Mappers.Utilities;

using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class ClosedRentalRenewalMapper
    {
        public static readonly Func<LE.ClosedRentalRenewal, DB.ClosedRentalRenewal> ToDb =
            closedRentalRenewal => new DB.ClosedRentalRenewal
            {
                Id = closedRentalRenewal.Id,
                RentalId = closedRentalRenewal.Rental.Id,
                //Rental = ClosedRentalMapper.ToDb(closedRentalRenewal.Rental),
                OldEndDate = closedRentalRenewal.OldEndDate,
                NewEndDate = closedRentalRenewal.NewEndDate,
                TypeId = closedRentalRenewal.Type.Id,
                //Type = RentalRenewalTypeMapper.ToDb(closedRentalRenewal.Type)
            };

        public static readonly Func<DB.ClosedRentalRenewal, LE.ClosedRentalRenewal> ToLogic =
            closedRentalRenewal => new LE.ClosedRentalRenewal
            {
                Id = closedRentalRenewal.Id,
                Rental = ClosedRentalMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.ClosedRental, DB.ClosedRental>
                    (closedRentalRenewal.RentalId)),
                OldEndDate = closedRentalRenewal.OldEndDate,
                NewEndDate = closedRentalRenewal.NewEndDate,
                Type = RentalRenewalTypeMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.RentalRenewalType, DB.RentalRenewalType>
                    (closedRentalRenewal.TypeId))
            };
    }
}
