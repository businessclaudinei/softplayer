using Accounting.Interest.Infrastruture.Service.Resources.Cache;
using NSubstitute;

namespace Accounting.Interest.Domain.Test.Unit.Commands.v1.CalculateInterest.Mocks.Cache
{
    public sealed class CacheMock
    {
        public ICacheService GetCachedMock()
        {
            var mock = Substitute.For<ICacheService>();

            

            return mock;
        }
    }
}
