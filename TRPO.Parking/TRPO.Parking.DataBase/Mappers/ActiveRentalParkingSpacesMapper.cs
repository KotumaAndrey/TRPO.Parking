using System;
using TRPO.Parking.DataBase.Mappers.Utilities;
using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class ActiveRentalParkingSpacesMapper
    {
        public static readonly Func<LE.ActiveRentalParkingSpaces, DB.ActiveRentalParkingSpaces> ToDb =
            activeRentalParkingSpaces => new DB.ActiveRentalParkingSpaces
            {
                ActiveRentalId = activeRentalParkingSpaces.ParkingSpace.Id,
                //ActiveRental = ActiveRentalMapper.ToDb(activeRentalParkingSpaces.ActiveRental),
                ParkingSpaceId = activeRentalParkingSpaces.ParkingSpace.Id,
                //ParkingSpace = ParkingSpaceMapper.ToDb(activeRentalParkingSpaces.ParkingSpace),
            };

        public static readonly Func<DB.ActiveRentalParkingSpaces, LE.ActiveRentalParkingSpaces> ToLogic =
            activeRentalParkingSpaces => new LE.ActiveRentalParkingSpaces
            {
                ActiveRental = ActiveRentalMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.ActiveRental, DB.ActiveRental>
                    (activeRentalParkingSpaces.ActiveRentalId)),
                ParkingSpace = ParkingSpaceMapper.ToLogic(GetEntityFromDb.GetWithIntId<LE.ParkingSpace, DB.ParkingSpace>
                    (activeRentalParkingSpaces.ParkingSpaceId)),
            };
    }
}
