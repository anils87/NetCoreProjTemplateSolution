using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.Caching
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T GetCacheData<T>(object key, Func<T> func, int expirationInSeconds, bool isRelativeSliding = false)
        {
            var cachedValue = _memoryCache.GetOrCreate<T>(
                key, cacheEntry =>
                {
                    if(isRelativeSliding)
                    {
                        cacheEntry.SlidingExpiration = TimeSpan.FromSeconds(expirationInSeconds);
                    }
                    else
                    {
                        cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(expirationInSeconds);
                    }
                    T t = func();
                    return t;
                }
            );
            return cachedValue;
        }

        public Task<T> GetCacheDataAsync<T>(object key, Func<Task<T>> func, int expirationInSeconds, bool isRelativeSliding = false)
        {
            var cachedValue = _memoryCache.GetOrCreateAsync<T>(
                key, async cacheEntry =>
                {
                    if (isRelativeSliding)
                    {
                        cacheEntry.SlidingExpiration = TimeSpan.FromSeconds(expirationInSeconds);
                    }
                    else
                    {
                        cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(expirationInSeconds);
                    }
                    T t = await func();
                    return t;
                }
            );
            return cachedValue;
        }
    }
}
