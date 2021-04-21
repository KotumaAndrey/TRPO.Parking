using System;
using TRPO.Parking.DataBase.Mappers.Utilities;
using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class ActiveRentalMapper
    {
        public static readonly Func<LE.ActiveRental, DB.ActiveRental> ToDb =
            activeRental => new DB.ActiveRental
            {
                Id = activeRental.Id,
                ClientId = activeRental.Client.Id,
                //Client = ClientMapper.ToDb(activeRental.Client),
                ParkingSpaceId = activeRental.ParkingSpace.Id,
                //ParkingSpace = ParkingSpaceMapper.ToDb(activeRental.ParkingSpace),
                OpenDate = activeRental.OpenDate,
                ExpectedCloseDate = activeRental.ExpectedCloseDate
            };

        public static readonly Func<DB.ActiveRental, LE.ActiveRental> ToLogic =
            activeRental => new LE.ActiveRental
            {
                Id = activeRental.Id,
                Client = ClientMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.Client, DB.Client>
                    (activeRental.ClientId)),
                ParkingSpace = ParkingSpaceMapper.ToLogic(GetEntityFromDb.GetWithIntId <LE.ParkingSpace, DB.ParkingSpace>
                    (activeRental.ParkingSpaceId)),
                OpenDate = activeRental.OpenDate,
                ExpectedCloseDate = activeRental.ExpectedCloseDate
            };
    }
}
