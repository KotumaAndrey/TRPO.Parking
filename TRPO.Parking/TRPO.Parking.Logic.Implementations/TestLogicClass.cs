using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Parking.Entities;
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

        public async Task<TestEntity> GetTestValue()
        {
            var str = await _testRepo.GetTestValue();
            var g = await _testRepo.GetGenders();

            var entity = new TestEntity
            {
                Strings = g,
                String = str,
                Length = str.Length,
            };

            return entity;
        }
    }
}
