using Accounting.Interest.CrossCutting.Configuration.CustomModels;
using Accounting.Interest.CrossCutting.Configuration.Extensions;
using Accounting.Interest.Infrastruture.Service.Resources.Cache;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Interest.Domain.Commands.CalculateInterest
{
    public class CalculateInterestCommandHandler : IRequestHandler<CalculateInterestCommand, CalculateInterestCommandResponse>
    {
        private readonly ICacheService _cacheService;

        public CalculateInterestCommandHandler(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<CalculateInterestCommandResponse> Handle(CalculateInterestCommand command, CancellationToken cancellation)
        {
            var compoundInterestAmount = command.Principal * (Math.Pow(1 + GetInterestRate(), command.TimeInMonths));

            return new CalculateInterestCommandResponse { CompoundInterestAmount = compoundInterestAmount.Truncate(2) };
        }

        private double GetInterestRate()
        {
            double? interestRate = 0.01;//await _cacheService.GetCachedResponseAsync<double?>(CustomSettings.Settings.Interest.Cache.Key);

            if (!interestRate.HasValue)
            {
                interestRate = 0.01; //call service;

                var timeToLive = new TimeSpan(0, CustomSettings.Settings.Interest.Cache.TimeToLive, 0);
                _cacheService.CacheResponseAsync(CustomSettings.Settings.Interest.Cache.Key, interestRate, timeToLive);
            }

            return interestRate.Value;
        }
    }
}
