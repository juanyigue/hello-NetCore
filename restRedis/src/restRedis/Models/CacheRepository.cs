using System;
using System.Collections.Generic;
using System.Collections.Concurrent;


namespace RestRedis.Models
{
    public class CacheItemRepository : ICacheRepository
    {
        static ConcurrentDictionary<string, CacheItem> _cache = new ConcurrentDictionary<string, CacheItem>();

        public CacheItemRepository()
        {
            Add(new CacheItem { Name = "Write the code", IsComplete = true });
            Add(new CacheItem { Name = "Implement API" });
            Add(new CacheItem { Name = "Create wiki page" });
        }

        public IEnumerable<CacheItem> GetAll()
        {
            return _cache.Values;
        }

        public void Add(CacheItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _cache[item.Key] = item;
        }

        public CacheItem Find(string key)
        {
            CacheItem item;
            _cache.TryGetValue(key, out item);
            return item;
        }

        public CacheItem Remove(string key)
        {
            CacheItem item;
            _cache.TryGetValue(key, out item);
            _cache.TryRemove(key, out item);
            return item;
        }

        public void Update(CacheItem item)
        {
            _cache[item.Key] = item;
        }
    }
}
