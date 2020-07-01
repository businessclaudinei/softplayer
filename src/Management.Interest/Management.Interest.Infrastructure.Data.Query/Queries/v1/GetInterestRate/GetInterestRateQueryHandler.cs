using AutoMapper;
using Management.Interest.CrossCutting.Configuration.CustomModels;
using Management.Interest.Infrastruture.Service.Resources.Cache;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Management.Interest.Infrastructure.Data.Query.Queries.v1.GetInterestRate
{
    public class GetInterestRateQueryHandler : IRequestHandler<GetInterestRateQuery, GetInterestRateQueryResponse>
    {
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public GetInterestRateQueryHandler(ICacheService cacheService, IMapper mapper)
        {
            _cacheService = cacheService;
            _mapper = mapper;
        }

        public async Task<GetInterestRateQueryResponse> Handle(GetInterestRateQuery query, CancellationToken cancellation)
        {
            var interestRate = await _cacheService.GetCachedResponseAsync<decimal?>(CustomSettings.Settings.Interest.Cache.Key);

            if (!interestRate.HasValue)
            {
                interestRate = CustomSettings.Settings.Interest.DefaultRate;

                var timeToLive = new TimeSpan(0, CustomSettings.Settings.Interest.Cache.TimeToLive, 0);
                _cacheService.CacheResponseAsync(CustomSettings.Settings.Interest.Cache.Key, interestRate, timeToLive);
            }
            return _mapper.Map<decimal?, GetInterestRateQueryResponse>(interestRate);
        }
    }
}
