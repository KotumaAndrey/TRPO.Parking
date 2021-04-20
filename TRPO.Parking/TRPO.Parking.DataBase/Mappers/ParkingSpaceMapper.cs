using System;
using TRPO.Parking.DataBase.EnumEntities;

using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class ParkingSpaceMapper
    {
        public static readonly Func<LE.ParkingSpace, DB.ParkingSpace> ToDb =
            parkingSpace => new DB.ParkingSpace
            {
                Id = parkingSpace.Id,
                FloorId = parkingSpace.Floor.Id,
                Floor = FloorMapper.ToDb(parkingSpace.Floor),
                Row = parkingSpace.Row,
                Colunm = parkingSpace.Colunm,
                StatusId = parkingSpace.Status,
                Status = new ParkingSpaceStatusEntity(parkingSpace.Status)
            };

        public static readonly Func<DB.ParkingSpace, LE.ParkingSpace> ToLogic =
            parkingSpace => new LE.ParkingSpace
            {
                Id = parkingSpace.Id,
                Floor = FloorMapper.ToLogic(parkingSpace.Floor),
                Row = parkingSpace.Row,
                Colunm = parkingSpace.Colunm,
                Status = parkingSpace.StatusId
            };
    }
}
