using System;

using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class FloorMapper
    {
        public static readonly Func<LE.Floor, DB.Floor> ToDb =
           floor => new DB.Floor
           {
               Id = floor.Id,
               RowCount = floor.RowCount,
               ColumnCount = floor.ColumnCount
           };

        public static readonly Func<DB.Floor, LE.Floor> ToLogic =
            floor => new LE.Floor
            {
                Id = floor.Id,
                RowCount = floor.RowCount,
                ColumnCount = floor.ColumnCount
            };
    }
}
