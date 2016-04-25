using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restRedis3.Models
{
    public interface ICacheRepository
    {
        void Add(CacheItem item);
        IEnumerable<CacheItem> GetAll();
        CacheItem Find(string key);
        CacheItem Remove(string key);
        void Update(CacheItem item);
    }
}
