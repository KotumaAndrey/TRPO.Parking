using System;

using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class ClosedRentalParkingSpacesMapper
    {
        public static readonly Func<LE.ClosedRentalParkingSpaces, DB.ClosedRentalParkingSpaces> ToDb =
            closedRentalParkingSpaces => new DB.ClosedRentalParkingSpaces
            {
                ClosedRentalId = closedRentalParkingSpaces.ClosedRental.Id,
                ClosedRental = ClosedRentalMapper.ToDb(closedRentalParkingSpaces.ClosedRental),
                ParkingSpaceId = closedRentalParkingSpaces.ParkingSpace.Id,
                ParkingSpace = ParkingSpaceMapper.ToDb(closedRentalParkingSpaces.ParkingSpace)
            };

        public static readonly Func<DB.ClosedRentalParkingSpaces, LE.ClosedRentalParkingSpaces> ToLogic =
            closedRentalParkingSpaces => new LE.ClosedRentalParkingSpaces
            {
                ClosedRental = ClosedRentalMapper.ToLogic(closedRentalParkingSpaces.ClosedRental),
                ParkingSpace = ParkingSpaceMapper.ToLogic(closedRentalParkingSpaces.ParkingSpace)
            };
    }
}
