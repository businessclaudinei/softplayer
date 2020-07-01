using System.Net.Http;
using System.Threading.Tasks;

namespace Accounting.Interest.Infrastructure.Service.ServiceHandler
{
    public interface IContentTypeGenerator
        {
            HttpContent GenerateRequestContent<TRequest>(TRequest request);

            Task<TResponse> GenerateResponseContent<TResponse>(HttpResponseMessage httpResponse);
        }

}
