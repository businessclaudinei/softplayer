using Newtonsoft.Json;

namespace Management.Interest.Infrastruture.Data.Query.Queries.GetInterestRate
{
    public class GetInterestRateQueryResponse
    {
        [JsonProperty("interestRate")]
        public decimal InterestRate { get; set; }

        [JsonProperty("formattedInterestRate")]
        public string FormattedInterestRate { get; set; }
    }
}
