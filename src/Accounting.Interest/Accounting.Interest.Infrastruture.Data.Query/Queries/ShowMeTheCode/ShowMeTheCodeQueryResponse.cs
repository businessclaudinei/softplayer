
using Newtonsoft.Json;

namespace Accounting.Interest.Insfrastruture.Data.Query.Queries.ShowMeTheCode
{ 
    public class ShowMeTheCodeQueryResponse
    {
        [JsonProperty("gitHubRepositoryUrl")]
        public string GitHubRepositoryUrl { get; set; }
    }
}
