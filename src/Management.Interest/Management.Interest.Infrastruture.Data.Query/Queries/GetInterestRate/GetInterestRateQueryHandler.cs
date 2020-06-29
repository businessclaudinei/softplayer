using Management.Interest.Infrastruture.Service.Resources.Cache;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Management.Interest.Infrastruture.Data.Query.Queries.GetInterestRate
{
    public class GetInterestRateQueryHandler : IRequestHandler<GetInterestRateQuery, GetInterestRateQueryResponse>
    {
        private readonly IResponseCacheService _responseCacheService;

        public GetInterestRateQueryHandler(IResponseCacheService responseCacheService)
        {
            _responseCacheService = responseCacheService;
        }

        public async Task<GetInterestRateQueryResponse> Handle(GetInterestRateQuery query, CancellationToken cancellation)
        {
            decimal interestRate = 0;

            var cachedValue = await _responseCacheService.GetCachedResponseAsync("test");

            if (cachedValue != null)
            {
                interestRate = JsonConvert.DeserializeObject<decimal>(cachedValue);
                await _responseCacheService.CacheResponseAsync("test", interestRate + 1, new TimeSpan(0, 0, 20)).ConfigureAwait(false);
            }
            else
            {
                await _responseCacheService.CacheResponseAsync("test", 1, new TimeSpan(0, 0, 20)).ConfigureAwait(false);
            }
            return new GetInterestRateQueryResponse { InterestRate = interestRate, FormattedInterestRate = interestRate.ToString("c")};
        }
    }
}
