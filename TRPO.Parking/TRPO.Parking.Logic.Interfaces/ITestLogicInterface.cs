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
        Task<IEnumerable<string>> GetTestValue();
        Task<IEnumerable<string>> GetGenders();
        Task<IEnumerable<string>> GetClientTypes();
        Task<IEnumerable<string>> GetRentalRenewalTypes();
    }
}
