using Newtonsoft.Json;

namespace Accounting.Interest.CrossCutting.Configuration.AppModels
{
    public sealed class ErrorSettings
    {
        [JsonProperty("detailed")]
        public bool Detailed { get; set; }
    }
}
