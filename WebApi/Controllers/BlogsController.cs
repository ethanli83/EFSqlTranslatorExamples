using System.Collections.Generic;
using System.Linq;
using DataModel;
using EFSqlTranslator.EFModels;
using EFSqlTranslator.Translation;
using EFSqlTranslator.Translation.DbObjects.SqliteObjects;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            using (var db = new BloggingContext())
            {
                var query = db.Blogs;

                var blogs = db.Query(
                    query,
                    new EFModelInfoProvider(db),
                    new SqliteObjectFactory());

                return blogs;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Blog Get(int id)
        {
            using (var db = new BloggingContext())
            {
                var query = db.Blogs.Where(b => b.BlogId == id);

                var blogs = db.Query(
                    query,
                    new EFModelInfoProvider(db),
                    new SqliteObjectFactory());

                return blogs.SingleOrDefault();
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
