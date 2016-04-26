using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSRedis;

namespace RestRedis.Logic
{
    public class CacheManager
    {
        private RedisClient redisCli;

        public CacheManager()
        {
        }

        public CacheManager(string host, string port)
        {
            redisCli = new RedisClient(host, Convert.ToInt32(port));
        }

        public string Ping()
        {
            return redisCli.Ping();
        }

        public string SayHello()
        {
            return redisCli.Echo("hello world from Redis");
        }

        public DateTime GiveTime()
        {
            return redisCli.Time();
        }

        public void SetValue(string key, string value)
        {
            redisCli.Set(key, value);
        }

        public string GetValue(string key)
        {
            return redisCli.Get(key);
        }


    }
}
