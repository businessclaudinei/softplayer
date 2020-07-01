using Accounting.Interest.CrossCutting.Configuration.AppModels;
using Accounting.Interest.CrossCutting.Exception.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Accounting.Interest.Infrastructure.Service.ServiceHandler
{
    public class HttpServiceClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public HttpServiceClient(IHttpClientFactory httpClientFactory, ILogger logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public virtual string ServiceClientId { get; private set; }

        public async Task<HttpServiceClientResponse<TResponse>> GetAsync<TResponse>(string endpoint, Dictionary<string, string> customHeaders = null)
        {
            string address = AppSettings.Settings.ServiceClients[ServiceClientId].Address;
            string formattedAddress = !string.IsNullOrEmpty(address) ? address.TrimEnd('/') : string.Empty;
            string formattedEndpoint = !string.IsNullOrEmpty(endpoint) ? endpoint.TrimStart('/') : string.Empty;

            string url = formattedAddress + "/" + formattedEndpoint;

            HttpServiceClientResponse<TResponse> serviceClientResponse;
            try
            {
                var client = _httpClientFactory.CreateClient();
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

                if (customHeaders != null && customHeaders.Any())
                    foreach (KeyValuePair<string, string> header in customHeaders)
                        httpRequestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);

                var httpResponse = await client.SendAsync(httpRequestMessage);

                serviceClientResponse =
                    httpResponse != null ? new HttpServiceClientResponse<TResponse>(httpResponse) : null;
            }
            catch (Exception ex)
            {
                var serviceClientException =
                    new ApiHttpCustomException($"GET {url}", HttpStatusCode.InternalServerError, ex);
                _logger.LogError(serviceClientException, "An exception has occurred during a http connection.");
                throw serviceClientException;
            }

            return serviceClientResponse;
        }

    }
}
