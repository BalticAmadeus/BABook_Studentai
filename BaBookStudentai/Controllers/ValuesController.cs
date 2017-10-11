using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaBookStudentai.Entities;
using BaBookStudentai.Models;

namespace BaBookStudentai.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private BaBookDbContext db = new BaBookDbContext();



        // GET api/values
        public IEnumerable<string> Get()
        {
            Group group = new Group
            {
                Name = "Alus"

            };
            db.Group.Add(group);
            db.SaveChanges();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
