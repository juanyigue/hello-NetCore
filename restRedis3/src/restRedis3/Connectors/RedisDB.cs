using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;


namespace restRedis3.Connectors
{
    public class RedisDB
    {

        private ConnectionMultiplexer redisCli;
        private IDatabase db;
        private string host = "192.168.99.100";
        private string port = "6379";

        public RedisDB()
        {
        }

        public RedisDB(string _host, string _port)
        {

            //ConfigurationOptions configuration = new ConfigurationOptions();
            //configuration.AbortOnConnectFail = false;

            //redisCli = ConnectionMultiplexer.Connect("192.168.99.100:6379,abortConnect=false,resolveDns=false,allowAdmin=true,ssl=false");
            redisCli = ConnectionMultiplexer.Connect(string.Format("{0}:{1},abortConnect=false,resolveDns=false,allowAdmin=true,ssl=false", host, port));

            db = redisCli.GetDatabase();

            //Nhiredis.RedisClient a = new RedisClient("192.168.99.100", 6379, TimeSpan.FromSeconds(10));

            //redisCli = ConnectionMultiplexer.ConnectAsync("192.168.99.100:6379");

            //redisCli = ConnectionMultiplexer.Connect("192.168.99.100:6379");

            //redisCli = new redisCli.(host, Convert.ToInt32(port));
        }

        public string Ping()
        {
            return db.Ping().ToString();
        }

        //public string SayHello()
        //{
        //    return db.Echo("hello world from Redis");
        //}

        //public DateTime GiveTime()
        //{
        //    return db.Time();
        //}


        public void SetValue(string key, string value)
        {
            db.StringSet(key, value);
        }

        public string GetValue(string key)
        {
            return db.StringGet(key);
        }

        public IDictionary<string, string> GetAll()
        {
            IServer server = redisCli.GetServer(string.Format("{0}:{1}", host, port));

            IEnumerable<RedisKey> keys = server.Keys();
            //for(int i = 0;i< keys.Count(); i++)
            //{
            //}
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (RedisKey key in keys)
            {
                dictionary.Add(key.ToString(), GetValue(key.ToString()));
            }

            return dictionary;
        }

    }
}
