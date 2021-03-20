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

        public TestEntity GetTestValue()
        {
            string str = _testRepo.GetTestValue();
            return new TestEntity
            {
                String = str,
                Length = str.Length,
            };
        }
    }
}
