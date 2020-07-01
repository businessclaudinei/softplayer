using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Accounting.Interest.Domain.Commands.CalculateInterest
{
    public class CalculateInterestCommand : IRequest<CalculateInterestCommandResponse>
    {
        [JsonProperty("timeInMonths")]
        public int TimeInMonths { get; set; }

        [JsonProperty("principal")]
        public double Principal { get; set; }
    }
}
