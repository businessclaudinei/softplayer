
using Newtonsoft.Json;

namespace Accounting.Interest.Domain.Commands.CalculateInterest
{
    public class CalculateInterestCommandResponse
    {
        [JsonProperty("compoundInterestAmount")]
        public decimal CompoundInterestAmount { get; set; }

        [JsonProperty("formattedCompoundInterestAmount")]
        public string FormattedCompoundInterestAmount { get; set; }
    }
}
