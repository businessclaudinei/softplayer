
using Newtonsoft.Json;

namespace Accounting.Interest.Domain.Commands.CalculateInterest
{
    public class CalculateInterestCommandResponse
    {
        /// <summary>
        /// Valor do juros composto
        /// </summary>
        [JsonProperty("compoundInterestAmount")]
        public decimal CompoundInterestAmount { get; set; }

        /// <summary>
        /// Valor do juros composto formatado
        /// </summary>
        [JsonProperty("formattedCompoundInterestAmount")]
        public string FormattedCompoundInterestAmount { get; set; }
    }
}
