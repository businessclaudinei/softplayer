using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Accounting.Interest.CrossCutting.Exception.Base;

namespace Accounting.Interest.Infrastructure.Service.ServiceHandler
{
    public class HttpServiceClientResponse<TResponse>
    {
        public HttpResponseMessage HttpResponse { get; }

        public HttpServiceClientResponse(HttpResponseMessage httpResponse)
        {
            this.HttpResponse = httpResponse;
        }

        public async Task<TResponse> GetContentObjectAsync()
        {
            try
            {
                return await new JsonContentTypeGenerator().GenerateResponseContent<TResponse>(this.HttpResponse);
            }
            catch (Exception ex)
            {
                if (HttpResponse != null)
                {
                    var url = HttpResponse.RequestMessage?.RequestUri?.ToString();
                    var httpVerb = HttpResponse.RequestMessage?.Method?.Method;
                    
                    throw new ApiHttpCustomException($"{httpVerb} {url}, obj:{typeof(TResponse)}", HttpStatusCode.UnprocessableEntity, ex);
                }

                throw new ApiHttpCustomException(ex.Message);
            }
        }
    }
}
