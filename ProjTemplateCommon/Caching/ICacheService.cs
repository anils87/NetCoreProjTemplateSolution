using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.Caching
{
    public interface ICacheService
    {
        public T GetCacheData<T>(object key, Func<T> func, int expirationInSeconds, bool isRelativeSliding = false);
        public Task<T> GetCacheDataAsync<T>(object key, Func<Task<T>> func, int expirationInSeconds, bool isRelativeSliding = false);
    }
}
