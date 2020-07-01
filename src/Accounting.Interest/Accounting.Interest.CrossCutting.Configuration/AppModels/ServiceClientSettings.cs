using Newtonsoft.Json;

namespace Accounting.Interest.CrossCutting.Configuration.AppModels
{
    public sealed class ServiceClientSettings
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("timeout")]
        public int TimeOut { get; set; }
    }
}
