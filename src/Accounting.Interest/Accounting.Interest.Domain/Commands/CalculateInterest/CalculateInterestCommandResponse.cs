
using Newtonsoft.Json;

namespace Accounting.Interest.Domain.Commands.CalculateInterest
{
    public class CalculateInterestCommandResponse
    {
        /// <summary>
        /// The compound interest aAmount
        /// </summary>
        [JsonProperty("compoundInterestAmount")]
        public double CompoundInterestAmount { get; set; }

        /// <summary>
        /// The compound interest amount's currency code
        /// </summary>
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
    }
}
