using Accounting.Interest.Infrastructure.Service.Services.Management;
using System.Threading.Tasks;

namespace Accounting.Interest.Infrastructure.Service.Interfaces.Management
{
    public interface IManagementInterestApiServiceClient
    {
        Task<InterestRateServiceResponse> GetInterestRate();
    }
}
