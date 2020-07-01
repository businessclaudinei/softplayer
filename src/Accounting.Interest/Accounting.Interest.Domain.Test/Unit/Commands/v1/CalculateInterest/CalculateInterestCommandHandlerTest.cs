using Accounting.Interest.Domain.Commands.CalculateInterest;
using Accounting.Interest.Domain.Test.Unit.Commands.v1.CalculateInterest.Mocks.Cache;
using AutoFixture;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Accounting.Interest.Domain.Test.Unit.Commands.v1.CalculateInterest.Mocks.Service;

namespace Accounting.Interest.Domain.Test.Unit.Commands.v1.CalculateInterest
{
    [TestFixture]
    public sealed class CalculateInterestCommandHandlerTest
    {
        private CalculateInterestCommandHandler _defaultContext;
        private ManagementInterestApiServiceClientMock _managementInterestApiServiceClientMock;
        private CacheMock _cacheMock;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
            _cacheMock = new CacheMock();
            _managementInterestApiServiceClientMock = new ManagementInterestApiServiceClientMock();
            _defaultContext = new CalculateInterestCommandHandler(_cacheMock.GetCachedMock(), _managementInterestApiServiceClientMock.GetMock());
        }

        [TestCase(5,100)]
        public async Task Should_CalculateInterest_ForValidRequest(int timeInMonths, double principal)
        {
            var request = new CalculateInterestCommand();
            request.TimeInMonths = timeInMonths;
            request.Principal = principal;

            var response = await _defaultContext.Handle(request, CancellationToken.None);

            Assert.NotNull(response);
            Assert.AreEqual(105.1, response.CompoundInterestAmount);
        }
    }
}
