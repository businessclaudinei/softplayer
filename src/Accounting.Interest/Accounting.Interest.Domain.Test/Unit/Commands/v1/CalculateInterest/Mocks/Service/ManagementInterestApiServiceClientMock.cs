using Accounting.Interest.Domain.Test.Unit.Commands.v1.CalculateInterest.Mocks.Specimen;
using Accounting.Interest.Infrastructure.Service.Interfaces.Management;
using Accounting.Interest.Infrastructure.Service.Services.Management;
using AutoFixture;
using NSubstitute;

namespace Accounting.Interest.Domain.Test.Unit.Commands.v1.CalculateInterest.Mocks.Service
{
    public sealed class ManagementInterestApiServiceClientMock
    {
        public IManagementInterestApiServiceClient GetMock()
        {
            var mock = Substitute.For<IManagementInterestApiServiceClient>();

            var fixture = new Fixture();
            fixture.Customizations.Add(new InterestRateServiceResponseSpecimen());

            mock.GetInterestRate().Returns(fixture.Create<InterestRateServiceResponse>());

            return mock;
        }
    }
}
