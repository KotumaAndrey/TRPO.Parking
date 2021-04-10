using System;
using System.Collections.Generic;
using System.Text;
using TRPO.Parking.DataBase;
using TRPO.Parking.Utilitas.Pathfinder;

namespace TRPO.Parking.Repositories.Implementations
{
    internal class BaseRepository
    {
        private IPathfinder _pathfinder;

        public BaseRepository(IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
        }

        protected ParkingDbContext CreateConection()
        {
            var db = new ParkingDbContext(_pathfinder);
            //db.Database.Migrate();
            return db;
        }
    }
}
