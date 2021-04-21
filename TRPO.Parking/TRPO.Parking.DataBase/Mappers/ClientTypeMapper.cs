using System;

using DB = TRPO.Parking.DataBase.EnumEntities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class ClientTypeMapper
    {
        public static readonly Func<LE.ClientTypeEntity, DB.ClientTypeEntity> ToDb =
            clientType => new DB.ClientTypeEntity
            {
                Id = clientType.Type,
                Price = clientType.Price,
                Title = clientType.Type.ToString()
            };

        public static readonly Func<DB.ClientTypeEntity, LE.ClientTypeEntity> ToLogic =
            clientType => new LE.ClientTypeEntity
            {
                Type = clientType.Id,
                Price = clientType.Price
            };
    }
}
