using Accounting.Interest.CrossCutting.Exception.Base;
using Accounting.Interest.Infrastructure.Service.Interfaces.Management;
using Accounting.Interest.Infrastructure.Service.Services.Management;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace Accounting.Interest.Infrastructure.Service.ServiceHandler.Management
{
    public class ManagementInterestApiServiceClient : HttpServiceClient, IManagementInterestApiServiceClient
    {
        public ManagementInterestApiServiceClient(IHttpClientFactory httpClientFactory, ILogger logger) 
            : base(httpClientFactory, logger)
        {
        }

        public override string ServiceClientId => "ManagementInterestApiServiceClientApi";

        public async Task<InterestRateServiceResponse> GetInterestRate()
        {

            //request.Headers.Add("Accept", "application/json");
            //request.Headers.Add("Content-Type", "application/json");

            var response = await GetAsync<InterestRateServiceResponse>("v1/taxa-juros");

            if (!response.HttpResponse.IsSuccessStatusCode)
                throw new ApiHttpCustomException();

            return await response.GetContentObjectAsync();
        }

    }
}
