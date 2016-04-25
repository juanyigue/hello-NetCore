using System;
using System.Collections.Generic;
using System.Collections.Concurrent;


namespace restRedis3.Models
{
    public class CacheRepository : ICacheRepository
    {
        static ConcurrentDictionary<string, CacheItem> _cacheItems = new ConcurrentDictionary<string, CacheItem>();

        public CacheRepository()
        {
            Add(new CacheItem { Name = "Write the code", IsComplete = true });
            Add(new CacheItem { Name = "Implement API" });
            Add(new CacheItem { Name = "Create wiki page" });
        }

        public IEnumerable<CacheItem> GetAll()
        {
            return _cacheItems.Values;
        }

        public void Add(CacheItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _cacheItems[item.Key] = item;
        }

        public CacheItem Find(string key)
        {
            CacheItem item;
            _cacheItems.TryGetValue(key, out item);
            return item;
        }

        public CacheItem Remove(string key)
        {
            CacheItem item;
            _cacheItems.TryGetValue(key, out item);
            _cacheItems.TryRemove(key, out item);
            return item;
        }

        public void Update(CacheItem item)
        {
            _cacheItems[item.Key] = item;
        }
    }
}
