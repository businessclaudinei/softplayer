using Newtonsoft.Json;

namespace Management.Interest.CrossCutting.Configuration.CustomModels
{
    public sealed class InterestSettings
    {
        /// <summary>
        /// The cache settings information
        /// </summary>
        [JsonProperty("cache")]
        public CacheSettings Cache { get; set; }

        /// <summary>
        /// The default interest rate amount
        /// </summary>
        [JsonProperty("defaultRate")]
        public double DefaultRate { get; set; }
    }
}
