using Accounting.Interest.Infrastruture.Service.Resources.Cache;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Interest.Domain.Commands.CalculateInterest
{
    public class CalculateInterestCommandHandler : IRequestHandler<CalculateInterestCommand, CalculateInterestCommandResponse>
    {
        private readonly IResponseCacheService _responseCacheService;

        public CalculateInterestCommandHandler(IResponseCacheService responseCacheService)
        {
            _responseCacheService = responseCacheService;
        }

        public async Task<CalculateInterestCommandResponse> Handle(CalculateInterestCommand command, CancellationToken cancellation)
        {
            decimal compoundInterestAmount = 0;

            var cachedValue = await _responseCacheService.GetCachedResponseAsync("test");

            if (cachedValue != null)
            {
                compoundInterestAmount = JsonConvert.DeserializeObject<decimal>(cachedValue);
                await _responseCacheService.CacheResponseAsync("test", compoundInterestAmount+1, new TimeSpan(0, 0, 20)).ConfigureAwait(false);
            }
            else
            {
                await _responseCacheService.CacheResponseAsync("test", 1, new TimeSpan(0, 0, 20)).ConfigureAwait(false);
            }

            return new CalculateInterestCommandResponse { CompoundInterestAmount = compoundInterestAmount };
        }
    }
}
