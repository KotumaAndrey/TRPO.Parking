using System;
using System.Linq;
using TRPO.Parking.DataBase.EntityInterfaces;
using TRPO.Parking.DataBase.EnumEntities;
using TRPO.Parking.Utilitas.Pathfinder;

using EF = Microsoft.EntityFrameworkCore.Internal;

namespace TRPO.Parking.DataBase.Mappers.Utilities
{
    public static class GetEntityFromDb    {
        public static IPathfinder Pathfinder { get; set; }

        public static DB GetWithIntId<LE, DB>(int entityId)
            where LE : class
            where DB : class, IEntityWithIntId
        {
            using(var db = new ParkingDbContext(Pathfinder))
            {
                var typeName = typeof(LE).Name + "s";
                var property = db.GetType().GetProperty(typeName);
                var values = (EF.InternalDbSet<DB>)property.GetValue(db);

                return values.FirstOrDefault(e => e.Id == entityId);
            }
        }

        public static DB GetWithEnum<LE, DB, EE>(Enum entityId)
            where LE : class
            where DB : BaseEnumEntity<EE>
            where EE : Enum
        {
            using (var db = new ParkingDbContext(Pathfinder))
            {

                var typeName = typeof(LE).Name.TrimEnd('y') + "ies";
                var property = db.GetType().GetProperty(typeName);
                var values = (EF.InternalDbSet<DB>)property.GetValue(db);

                DB entity = null;
                foreach (var v in values)
                {
                    if (v.Id.Equals(entityId))
                    {
                        entity = v;
                    }
                }

                return entity;
            }
        }
    }
}
