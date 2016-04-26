using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using RestRedis.Models;
using RestRedis.Logic4;

namespace RestRedis.Controllers
{
    [Route("api/cache")]
    public class CacheController : Controller
    {

        CacheManager cm = new CacheManager();

        [FromServices]
        public ICacheRepository CacheItems { get; set; }

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

    }
}