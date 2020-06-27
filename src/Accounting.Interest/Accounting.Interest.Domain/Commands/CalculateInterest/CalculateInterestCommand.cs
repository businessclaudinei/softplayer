using MediatR;
using Newtonsoft.Json;

namespace Accounting.Interest.Domain.Commands.CalculateInterest
{
    public class CalculateInterestCommand : IRequest<CalculateInterestCommandResponse>
    {
        [JsonProperty("timeInMonths")]
        public short TimeInMonths { get; set; }

        [JsonProperty("principal")]
        public decimal Principal { get; set; }
    }
}
