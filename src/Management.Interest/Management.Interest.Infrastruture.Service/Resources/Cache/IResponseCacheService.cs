using System;
using System.Threading.Tasks;

namespace Management.Interest.Infrastruture.Service.Resources.Cache
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeTimeLive);

        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}
