using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Parking.Entities;

namespace TRPO.Parking.Logic.Interfaces
{
    public interface ITestLogicInterface
    {
        Task<TestEntity> GetTestValue();
    }
}
