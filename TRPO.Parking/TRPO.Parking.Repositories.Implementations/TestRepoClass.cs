using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Parking.DataBase;
using TRPO.Parking.Repositories.Interfaces;
using TRPO.Parking.Utilitas.Pathfinder;

namespace TRPO.Parking.Repositories.Implementations
{
    internal class TestRepoClass : BaseRepository, ITestRepoInterface
    {
        public TestRepoClass(IPathfinder pathfinder)
            : base(pathfinder)
        {

        }

        public async Task<string> GetTestValue()
        {
            return "Test value";
        }

        public async Task<IEnumerable<string>> GetGenders()
        {
            using (var db = CreateConection())
            {
                var genders = db.GenderEntities
                    .Select(x => x.Id.ToString())
                    .ToArray();

                return genders;
            }
        }
    }
}
