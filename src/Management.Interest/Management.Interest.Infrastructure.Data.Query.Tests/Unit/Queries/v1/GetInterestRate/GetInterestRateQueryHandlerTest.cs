using Management.Interest.CrossCutting.Exception;
using Management.Interest.Infrastructure.Data.Query.Queries.v1.GetInterestRate;
using Management.Interest.Infrastructure.Data.Query.Tests.Unit.Queries.v1.GetInterestRate.Mocks.Cache;
using Management.Interest.Infrastructure.Data.Query.Tests.Unit.Queries.v1.GetInterestRate.Mocks.Mappers;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Management.Interest.Infrastructure.Data.Query.Tests.Unit.Queries.v1.GetInterestRate
{
    public sealed class GetInterestRateQueryHandlerTest
    {
        private readonly CacheMock _cacheMock;
        private readonly MapperMock _mapperMock;
        private readonly GetInterestRateQueryHandler _defaultContext;

        public GetInterestRateQueryHandlerTest()
        {
            _cacheMock = new CacheMock();
            _mapperMock = new MapperMock();
            _defaultContext = new GetInterestRateQueryHandler(_cacheMock.GetMock(), _mapperMock.GetMock());
        }

        [Test, Property("Priority", 1)]
        public async Task Should_GetInterestRate_ForValidRequest()
        {
            var response = await _defaultContext.Handle(new GetInterestRateQuery(), CancellationToken.None);

            Assert.NotNull(response);
            Assert.AreEqual(0.01, response.InterestRate);
        }

        [Test, Property("Priority", 1)]
        public async Task Should_GetCachedInterestRate_ForValidRequest()
        {
            var cachedContext = new GetInterestRateQueryHandler(_cacheMock.GetCachedMock(), _mapperMock.GetMock());
            var response = await cachedContext.Handle(new GetInterestRateQuery(), CancellationToken.None);

            Assert.NotNull(response);
            Assert.AreEqual(0.01, response.InterestRate);
        }

        [Test, Property("Priority", 2)]
        public void ShouldNot_GetInterestRate_ForCacheRequestFailedException()
        {
            var exceptionContext = new GetInterestRateQueryHandler(_cacheMock.GetExceptionMock(), _mapperMock.GetMock());

            Assert.ThrowsAsync<CacheRequestFailedException>(() => exceptionContext.Handle(new GetInterestRateQuery(), CancellationToken.None));
        }

        [Test, Property("Priority", 2)]
        public void ShouldNot_GetInterestRate_ForNullReferenceException()
        {
            var exceptionContext = new GetInterestRateQueryHandler(null, null);

            Assert.ThrowsAsync<NullReferenceException>(() => exceptionContext.Handle(new GetInterestRateQuery(), CancellationToken.None));
        }
    }
}
