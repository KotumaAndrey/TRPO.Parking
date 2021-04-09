using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Parking.DataBase;
using TRPO.Parking.Repositories.Interfaces;

namespace TRPO.Parking.Repositories.Implementations
{
    internal class TestRepoClass : ITestRepoInterface
    {
        public async Task<string> GetTestValue()
        {
            return "Test value";
        }

        public async Task<IEnumerable<string>> GetGenders()
        {
            using (var db = new ParkingDbContext())
            {
                //db.Database.Migrate();

                var genders = db.GenderEntities
                    .Select(x => x.Id.ToString())
                    .ToArray();

                return genders;
            }
        }
    }
}
