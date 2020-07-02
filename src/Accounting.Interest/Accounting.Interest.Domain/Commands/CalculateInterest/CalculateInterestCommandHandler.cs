using Accounting.Interest.CrossCutting.Configuration.CustomModels;
using Accounting.Interest.CrossCutting.Configuration.Extensions;
using Accounting.Interest.Infrastructure.Service.Interfaces.Management;
using Accounting.Interest.Infrastructure.Service.Resources.Cache;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Interest.Domain.Commands.CalculateInterest
{
    public class CalculateInterestCommandHandler : IRequestHandler<CalculateInterestCommand, CalculateInterestCommandResponse>
    {
        private readonly ICacheService _cacheService;
        private readonly IManagementInterestApiServiceClient _managementInterestApiServiceClient;

        public CalculateInterestCommandHandler(ICacheService cacheService,
            IManagementInterestApiServiceClient managementInterestApiServiceClient)
        {
            _cacheService = cacheService;
            _managementInterestApiServiceClient = managementInterestApiServiceClient;
        }

        public async Task<CalculateInterestCommandResponse> Handle(CalculateInterestCommand command, CancellationToken cancellation)
        {
            var interestRateServiceResponse = await _managementInterestApiServiceClient.GetInterestRate();

            var compoundInterestAmount = command.Principal * Math.Pow(1 + interestRateServiceResponse.InterestRate, command.TimeInMonths);

            compoundInterestAmount = compoundInterestAmount.Truncate(2);

            Task.Run(() => SetCalculatedValuesHistory(command, interestRateServiceResponse.InterestRate, compoundInterestAmount));

            return new CalculateInterestCommandResponse { CompoundInterestAmount = compoundInterestAmount, CurrencyCode = CustomSettings.Settings.Interest.DefaultCurrencyCode};
        }

        private async Task SetCalculatedValuesHistory(CalculateInterestCommand command, double interestRate, double compoundInterestAmount)
        {
            var calculateResult = $"{command.Principal} x (1 + {interestRate}) ^ {command.TimeInMonths} = {compoundInterestAmount}";

            var timeToLive = new TimeSpan(0, CustomSettings.Settings.Interest.Cache.TimeToLive, 0);
            await _cacheService.CacheResponseAsync(CustomSettings.Settings.Interest.Cache.Key, calculateResult, timeToLive);
        }
    }
}
