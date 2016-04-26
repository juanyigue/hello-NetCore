using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using restRedis3.Connectors;

namespace restRedis3.Models
{
    public class CacheRepository : ICacheRepository
    {
        static ConcurrentDictionary<string, CacheItem> _cacheItems = new ConcurrentDictionary<string, CacheItem>();

        RedisDB db;

        public RedisDB MyDB
        {
            get { if (db == null) db = new RedisDB("testing", "6379"); return db; }
        }

        public CacheRepository()
        {
            //Add(new CacheItem { Name = "Write the code", IsComplete = true });
            //Add(new CacheItem { Name = "Write the code" });
            //Add(new CacheItem { Name = "Implement API" });
            //Add(new CacheItem { Name = "Create wiki page" });

            MyDB.SetValue("coun_1", "USA");
            MyDB.SetValue("coun_2", "Canada");
            MyDB.SetValue("coun_3", "Argentina");

            //Add(new CacheItem { Key = "coun_1", Name = "USA" });
            //Add(new CacheItem { Key = "coun_2", Name = "Candá" });
            //Add(new CacheItem { Key = "coun_3", Name = "Argentina" });
        }

        public IEnumerable<CacheItem> GetAll()
        {
            IDictionary<string, string> dictionary = MyDB.GetAll();
            _cacheItems.Clear();
            foreach ( KeyValuePair<string, string> item in dictionary)
            {
                _cacheItems[item.Key] = new CacheItem { Key = item.Key, Name = item.Value };
            }
            return _cacheItems.Values;
            //return _cacheItems.Values;
        }

        public void Add(CacheItem item)
        {
            //item.Key = Guid.NewGuid().ToString();
            _cacheItems[item.Key] = item;
        }

        public CacheItem Find(string theKey)
        {
            //CacheItem item;
            //_cacheItems.TryGetValue(key, out item);
            return new CacheItem{ Key = theKey, Name = MyDB.GetValue(theKey) };
            //return item;
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
