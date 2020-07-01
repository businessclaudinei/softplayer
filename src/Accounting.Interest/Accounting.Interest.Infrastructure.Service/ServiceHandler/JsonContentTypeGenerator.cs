using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Accounting.Interest.Infrastructure.Service.ServiceHandler
{
    internal class JsonContentTypeGenerator : IContentTypeGenerator
    {
        public HttpContent GenerateRequestContent<TRequest>(TRequest request)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(request, Formatting.None));
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return stringContent;
        }

        public async Task<TResponse> GenerateResponseContent<TResponse>(
            HttpResponseMessage httpResponse)
        {
            return JsonConvert.DeserializeObject<TResponse>(await httpResponse.Content.ReadAsStringAsync());
        }
    }
}
