using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRPO.Parking.Logic.Interfaces;
using TRPO.Parking.Repositories.Interfaces;

namespace TRPO.Parking.Logic.Implementations
{
    internal class TestLogicClass : ITestLogicInterface
    {
        private readonly ITestRepoInterface _testRepo;

        public TestLogicClass(ITestRepoInterface testRepo)
        {
            _testRepo = testRepo;
        }

        public async Task<IEnumerable<string>> GetTestValue()
        {
            var t = await _testRepo.GetTestValue();
            return t;
        }

        public async Task<IEnumerable<string>> GetClientTypes()
        {
            var t = await _testRepo.GetClientTypes();
            return t;
        }

        public async Task<IEnumerable<string>> GetGenders()
        {
            var t = await _testRepo.GetGenders();
            var res = t.Select(x => x.ToString()).ToArray();
            return res;
        }

        public async Task<IEnumerable<string>> GetRentalRenewalTypes()
        {
            var t = await _testRepo.GetRentalRenewalTypes();
            var res = t
                .Select(x => $"{x.Id} - ({x.PriceMultiplier}) - {x.From} : {x.To}")
                .ToArray();
            return res;
        }
    }
}
