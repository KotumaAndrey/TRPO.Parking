using System;
using TRPO.Parking.DataBase.Mappers.Utilities;
using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class ClosedRentalMapper
    {
        public static readonly Func<LE.ClosedRental, DB.ClosedRental> ToDb =
            closedRental => new DB.ClosedRental
            {
                Id = closedRental.Id,
                ClientId = closedRental.Client.Id,
                //Client = ClientMapper.ToDb(closedRental.Client),
                ParkingSpaceId = closedRental.ParkingSpace.Id,
                //ParkingSpace = ParkingSpaceMapper.ToDb(closedRental.ParkingSpace),
                OpenDate = closedRental.OpenDate,
                ExpectedCloseDate = closedRental.ExpectedCloseDate,
                RealCloseDate = closedRental.RealCloseDate,
                Price = closedRental.Price
            };

        public static readonly Func<DB.ClosedRental, LE.ClosedRental> ToLogic =
            closedRental => new LE.ClosedRental
            {
                Id = closedRental.Id,
                Client = ClientMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.Client, DB.Client>
                    (closedRental.ClientId)),
                ParkingSpace = ParkingSpaceMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.ParkingSpace, DB.ParkingSpace>
                    (closedRental.ParkingSpaceId)),
                OpenDate = closedRental.OpenDate,
                ExpectedCloseDate = closedRental.ExpectedCloseDate,
                RealCloseDate = closedRental.RealCloseDate,
                Price = closedRental.Price
            };
    }
}
