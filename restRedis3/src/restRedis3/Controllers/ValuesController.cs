using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using restRedis3.Connectors;
using restRedis3.Models;


namespace restRedis3.Controllers
{
    [Route("api/cache")]
    public class ValuesController : Controller
    {
        RedisDB db;

        [FromServices]
        public ICacheRepository CacheItems { get; set; }


        public ValuesController()
        {
            db = new RedisDB("testing", "6379");
            test2();

        }


        [HttpGet]
        public IEnumerable<CacheItem> GetAll()
        {
            return CacheItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetCache")]
        public IActionResult GetById(string id)
        {
            var item = CacheItems.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }


        private void test2()
        {
            try
            {
                Console.WriteLine("Write the host to connect to Redis: ");
                string host = Console.ReadLine();
                Console.WriteLine("Now write the port that Redis is listening to: ");
                string port = Console.ReadLine();

                RedisDB rdb = new RedisDB(host, port);


                Console.WriteLine("Doing ping to Redis...");
                Console.WriteLine(string.Format("Answer from Redis: {0}", rdb.Ping()));
                //Console.WriteLine(string.Format("Saying hello from Redis: {0}", rdb.SayHello()));
                //Console.WriteLine(string.Format("Redis, give me time: {0}", rdb.GiveTime().ToShortTimeString()));

                string key = "key1";
                Console.WriteLine(string.Format("Please, set a value for '{0}':", key));
                string value = Console.ReadLine();
                rdb.SetValue(key, value);
                string valueGot = rdb.GetValue(key);
                //Console.WriteLine(string.Format("Here is the value of '{0}': {1}", key, rdb.GetValue(key)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("An error has ocurred: {0}", ex));
            }
            finally
            {
                Console.WriteLine("\nPress any key to finish...");
                Console.ReadKey();
            }
        }




        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
