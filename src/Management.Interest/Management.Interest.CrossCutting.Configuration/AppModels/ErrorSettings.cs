using Newtonsoft.Json;

namespace Management.Interest.CrossCutting.Configuration.AppModels
{
    public sealed class ErrorSettings
    {
        [JsonProperty("detailed")]
        public bool Detailed { get; set; }
    }
}
