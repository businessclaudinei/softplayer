using Management.Interest.CrossCutting.Exception;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Management.Interest.Infrastruture.Service.Resources.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeTimeLive)
        {
            if (response == null) return;
            
            try
            {
                var serializedResponse = JsonConvert.SerializeObject(response);

                await _distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = timeTimeLive
                });
            }
            catch
            {
                throw new CacheRequestFailedException();
            }
        }

        public async Task<T> GetCachedResponseAsync<T>(string cacheKey)
        {
            try
            {
                var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);
                return string.IsNullOrEmpty(cachedResponse) ? default : JsonConvert.DeserializeObject<T>(cachedResponse);
            }
            catch
            {
                throw new CacheRequestFailedException();
            }
        }
    }
}
