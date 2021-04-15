using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<string>> GetTestValue()
        {
            return new []
            {
                "Test value1",
                "Test value2",
                "Test value3",
            };
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

        public async Task<IEnumerable<string>> GetClientTypes()
        {
            using (var db = CreateConection())
            {
                var clientTypes = db.ClientTypeEntities
                    .Select(x => $"{x.Id} - {x.Price}")
                    .ToArray();

                return clientTypes;
            }
        }

        public async Task<IEnumerable<string>> GetRentalRenewalTypes()
        {
            using (var db = CreateConection())
            {
                var renewalTypes = db.RentalRenewalTypes
                    .Select(x => $"{x.Id} - {x.Title} - ({x.PriceMultiplier}) - {x.From} : {x.To}")
                    .ToArray();

                return renewalTypes;
            }
        }
    }
}
