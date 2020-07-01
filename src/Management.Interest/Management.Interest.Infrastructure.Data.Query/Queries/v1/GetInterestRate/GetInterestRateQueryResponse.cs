﻿using Newtonsoft.Json;

namespace Management.Interest.Infrastructure.Data.Query.Queries.v1.GetInterestRate
{
    public class GetInterestRateQueryResponse
    {
        [JsonProperty("interestRate")]
        public double InterestRate { get; set; }

        [JsonProperty("formattedInterestRate")]
        public string FormattedInterestRate { get; set; }
    }
}
