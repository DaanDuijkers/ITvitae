using Microsoft.Extensions.Caching.Memory;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Phoneshop.Business
{
    [ExcludeFromCodeCoverage]
    public class Cache : ICache
    {
        private readonly MemoryCache cache = new(new MemoryCacheOptions());
        private readonly ConcurrentDictionary<object, SemaphoreSlim> locks = new();

        public void Delete(string key)
        {
            if (cache.TryGetValue(key, out _))
            {
                cache.Remove(key);
            }
        }

        public async Task<T> GetOrCreate<T>(string key, Func<Task<T>> createItem)
        {
            if (!cache.TryGetValue(key, out T item))
            {
                SemaphoreSlim myLock = locks.GetOrAdd(key, new SemaphoreSlim(1));

                await myLock.WaitAsync();

                try
                {
                    if (!cache.TryGetValue(key, out item))
                    {
                        item = await createItem();

                        var policies = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
                            .SetSlidingExpiration(TimeSpan.FromSeconds(30));

                        cache.Set(key, item, policies);
                    }
                }
                finally
                {
                    myLock.Release();
                }
            }

            return item;
        }
    }
}