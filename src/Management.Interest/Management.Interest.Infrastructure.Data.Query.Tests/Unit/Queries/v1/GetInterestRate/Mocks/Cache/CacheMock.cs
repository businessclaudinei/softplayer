using Management.Interest.CrossCutting.Configuration.CustomModels;
using Management.Interest.CrossCutting.Exception;
using Management.Interest.Infrastruture.Service.Resources.Cache;
using NSubstitute;
using System;

namespace Management.Interest.Infrastructure.Data.Query.Tests.Unit.Queries.v1.GetInterestRate.Mocks.Cache
{
    public sealed class CacheMock
    {
        public ICacheService GetCachedMock()
        {
            var mock = Substitute.For<ICacheService>();

            mock.GetCachedResponseAsync<decimal>(CustomSettings.Settings.Interest.Cache.Key).Returns(0.01M);

            return mock;
        }

        public ICacheService GetMock()
        {
            var mock = Substitute.For<ICacheService>();

            mock.GetCachedResponseAsync<decimal>(CustomSettings.Settings.Interest.Cache.Key).Returns(x => null);
            mock.CacheResponseAsync(Arg.Any<string>(), Arg.Any<object>(), Arg.Any<TimeSpan>());

            return mock;
        }

        public ICacheService GetExceptionMock()
        {
            var mock = Substitute.For<ICacheService>();

            mock.When(x => x.CacheResponseAsync(Arg.Any<string>(), Arg.Any<object>(), Arg.Any<TimeSpan>())).Do(x => { throw new CacheRequestFailedException(); });

            return mock;
        }
    }
}
