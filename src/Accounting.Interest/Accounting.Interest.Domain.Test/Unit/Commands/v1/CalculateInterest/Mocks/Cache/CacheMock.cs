using System;
using Accounting.Interest.Infrastructure.Service.Resources.Cache;
using NSubstitute;

namespace Accounting.Interest.Domain.Test.Unit.Commands.v1.CalculateInterest.Mocks.Cache
{
    public sealed class CacheMock
    {
        public ICacheService GetCachedMock()
        {
            var mock = Substitute.For<ICacheService>();

            mock.CacheResponseAsync(Arg.Any<string>(), Arg.Any<object>(), Arg.Any<TimeSpan>());

            return mock;
        }
    }
}
