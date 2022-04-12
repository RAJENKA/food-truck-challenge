using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodTruckChallenge
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, TimeSpan? timespan = null) where T : class
        {
            T item = _memoryCache.Get(cacheKey) as T;
            if (item != null)
            {
                return item;
            }

            item = getItemCallback();

            var expirationTimespan = timespan ?? TimeSpan.FromMinutes(1);
            _memoryCache.Set(cacheKey, item, expirationTimespan);

            return item;
        }

        public async Task<T> GetOrSetAsync<T>(string cacheKey, Func<Task<T>> getItemCallbackAsync, TimeSpan? timespan = null) where T : class
        {
            T item = _memoryCache.Get(cacheKey) as T;
            if (item != null)
            {
                return item;
            }

            item = await getItemCallbackAsync();

            var expirationTimespan = timespan ?? TimeSpan.FromMinutes(1);
            _memoryCache.Set(cacheKey, item, expirationTimespan);

            return item;
        }

        public void RemoveKeys(List<string> keys)
        {
            foreach (var key in keys)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
