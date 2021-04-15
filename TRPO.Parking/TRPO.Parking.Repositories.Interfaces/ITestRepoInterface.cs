using System.Collections.Generic;
using System.Threading.Tasks;

namespace TRPO.Parking.Repositories.Interfaces
{
    public interface ITestRepoInterface
    {
        Task<IEnumerable<string>> GetTestValue();
        Task<IEnumerable<string>> GetGenders();
        Task<IEnumerable<string>> GetClientTypes();
        Task<IEnumerable<string>> GetRentalRenewalTypes();
    }
}
