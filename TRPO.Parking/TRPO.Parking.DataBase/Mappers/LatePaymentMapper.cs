using System;
using TRPO.Parking.DataBase.Mappers.Utilities;
using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class LatePaymentMapper
    {
        public static readonly Func<LE.LatePayment, DB.LatePayment> ToDb =
           latePayment => new DB.LatePayment
           {
               Id = latePayment.Id,
               ClientId = latePayment.Client.Id,
               //Client = ClientMapper.ToDb(latePayment.Client),
               LatePaymentTypeId = latePayment.LatePaymentType.Id,
               //LatePaymentType = LatePaymentTypeMapper.ToDb(latePayment.LatePaymentType),
               ParkingSpaceId = latePayment.ParkingSpace.Id,
               //ParkingSpace = ParkingSpaceMapper.ToDb(latePayment.ParkingSpace),
               ActiveRentalId = latePayment.ActiveRental.Id,
               //ActiveRental = ActiveRentalMapper.ToDb(latePayment.ActiveRental),
               ClosedRentalId = latePayment.ClosedRental.Id,
               //ClosedRental = ClosedRentalMapper.ToDb(latePayment.ClosedRental),
           };

        public static readonly Func<DB.LatePayment, LE.LatePayment> ToLogic =
            latePayment => new LE.LatePayment
            {
                Id = latePayment.Id,
                Client = ClientMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.Client, DB.Client>(
                    latePayment.ClientId)),
                LatePaymentType = LatePaymentTypeMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.LatePaymentType, DB.LatePaymentType>(
                    latePayment.LatePaymentTypeId)),
                ParkingSpace = ParkingSpaceMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.ParkingSpace, DB.ParkingSpace>
                    (latePayment.ParkingSpaceId)),
                ActiveRental = ActiveRentalMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.ActiveRental, DB.ActiveRental>
                    ((int)latePayment.ActiveRentalId)),
                ClosedRental = ClosedRentalMapper.ToLogic(GetEntityFromDb.GetWithIntId <LE.ClosedRental, DB.ClosedRental>
                    ((int)latePayment.ClosedRentalId)),
            };
    }
}
