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
            var t = await _testRepo.GetTestValue();

            var entity = new TestEntity
            {
                Strings = t
            };

            return entity;
        }

        public async Task<TestEntity> GetClientTypes()
        {
            var t = await _testRepo.GetClientTypes();

            var entity = new TestEntity
            {
                Strings = t
            };

            return entity;
        }

        public async Task<TestEntity> GetGenders()
        {
            var t = await _testRepo.GetGenders();

            var entity = new TestEntity
            {
                Strings = t
            };

            return entity;
        }

        public async Task<TestEntity> GetRentalRenewalTypes()
        {
            var t = await _testRepo.GetRentalRenewalTypes();

            var entity = new TestEntity
            {
                Strings = t
            };

            return entity;
        }
    }
}
