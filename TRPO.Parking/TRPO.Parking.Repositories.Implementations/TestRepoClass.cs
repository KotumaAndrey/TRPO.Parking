using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Parking.Repositories.Interfaces;

namespace TRPO.Parking.Repositories.Implementations
{
    internal class TestRepoClass : ITestRepoInterface
    {
        public string GetTestValue()
        {
            return "Test value";
        }
    }
}
