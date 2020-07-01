using Newtonsoft.Json;

namespace Accounting.Interest.Infrastructure.Service.Services.Management
{
    public class InterestRateServiceResponse
    {
        [JsonProperty("interestRate")]
        public double InterestRate { get; set; }
    }
}
