using System.Collections.Generic;
using System.Threading.Tasks;
using TRPO.Parking.Entities;
using TRPO.Parking.Entities.Primitives;

namespace TRPO.Parking.Repositories.Interfaces
{
    public interface ITestRepoInterface
    {
        Task<IEnumerable<string>> GetTestValue();
        Task<IEnumerable<Gender>> GetGenders();
        Task<IEnumerable<string>> GetClientTypes();
        Task<IEnumerable<RentalRenewalType>> GetRentalRenewalTypes();
    }
}
