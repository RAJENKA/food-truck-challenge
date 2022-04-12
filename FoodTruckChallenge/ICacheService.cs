using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruckChallenge
{
    public interface ICacheService
    {
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, TimeSpan? timespan = null) where T : class;

        Task<T> GetOrSetAsync<T>(string cacheKey, Func<Task<T>> getItemCallbackAsync, TimeSpan? timespan = null) where T : class;

        void RemoveKeys(List<string> keys);
    }
}
