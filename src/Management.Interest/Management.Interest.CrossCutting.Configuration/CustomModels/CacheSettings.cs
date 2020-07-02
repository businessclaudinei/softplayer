using Newtonsoft.Json;

namespace Management.Interest.CrossCutting.Configuration.CustomModels
{
    public sealed class CacheSettings
    {
        /// <summary>
        /// The key of the cached object
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// The time in minutes the cached object will expire
        /// </summary>
        [JsonProperty("timeToLive")]
        public int TimeToLive { get; set; }

        /// <summary>
        /// The default currency code of interest amount
        /// </summary>
        [JsonProperty("defaultCurrencyCode")]
        public string DefaultCurrencyCode { get; set; }
    }
}
