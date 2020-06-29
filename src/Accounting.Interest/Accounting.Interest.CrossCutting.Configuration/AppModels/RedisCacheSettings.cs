using Newtonsoft.Json;

namespace Accounting.Interest.CrossCutting.Configuration.AppModels
{
    public sealed class RedisCacheSettings
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }
    }
}
