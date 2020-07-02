using Newtonsoft.Json;

namespace Management.Interest.Infrastructure.Data.Query.Queries.v1.GetInterestRate
{
    public class GetInterestRateQueryResponse
    {
        /// <summary>
        /// The interest rate
        /// </summary>
        [JsonProperty("interestRate")]
        public double InterestRate { get; set; }

        /// <summary>
        /// The currency code of the interestRate
        /// </summary>
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
    }
}
