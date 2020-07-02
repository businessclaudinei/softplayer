using Newtonsoft.Json;

namespace Accounting.Interest.CrossCutting.Configuration.CustomModels
{
    public sealed class InterestSettings
    {
        /// <summary>
        /// The cache settings information
        /// </summary>
        [JsonProperty("cache")]
        public CacheSettings Cache { get; set; }

        /// <summary>
        /// The interest's default currency code
        /// </summary>
        [JsonProperty("defaultCurrencyCode")]
        public string DefaultCurrencyCode { get; set; }
    }
}
