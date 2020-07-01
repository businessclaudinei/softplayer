using System;
using System.Threading.Tasks;

namespace Accounting.Interest.Infrastruture.Service.Resources.Cache
{
    public interface ICacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeTimeLive);

        Task<T> GetCachedResponseAsync<T>(string cacheKey);
    }
}
