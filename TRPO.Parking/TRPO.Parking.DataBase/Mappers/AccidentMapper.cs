using System;

using DB = TRPO.Parking.DataBase.Entities;
using LE = TRPO.Parking.Entities;

namespace TRPO.Parking.DataBase.Mappers
{
    public static class AccidentMapper
    {
        public static readonly Func<LE.Accident, DB.Accident> ToDb =
            accident => new DB.Accident
            {
                Id = accident.Id,
                AccidentDate = accident.AccidentDate,
                CulpritClientId = accident.CulpritClient.Id,
                //CulpritClient = ClientMapper.ToDb(accident.CulpritClient),
                Comment = accident.Comment
            };

        public static readonly Func<DB.Accident, LE.Accident> ToLogic =
            accident => new LE.Accident
            {
                Id = accident.Id,
                AccidentDate = accident.AccidentDate,
                CulpritClient = ClientMapper.ToLogic(accident.CulpritClient),
                Comment = accident.Comment
            };
    }
}
