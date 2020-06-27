using Newtonsoft.Json;

namespace TaxaJuros.Infrastruture.Data.Query.Queries.GetInterestRate
{
    public class GetInterestRateQueryResponse
    {
        [JsonProperty("interestRate")]
        public decimal InterestRate { get; set; }

        [JsonProperty("interestRateStr")]
        public string InterestRateStr { get; set; }
    }
}
