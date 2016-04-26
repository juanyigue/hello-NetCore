using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestRedis.Models
{
    public class CacheItem
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
