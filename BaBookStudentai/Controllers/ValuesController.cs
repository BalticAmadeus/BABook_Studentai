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
    [Authorize]
    public class ValuesController : ApiController
    {

        [Route("api/test")]
        [AllowAnonymous]
        public IHttpActionResult TEST()
        {
            using (var context = new BaBookDbContext())
            {
                var model = new User { UserId = 2, Username = "TEST" };
                var model2 = new Event
                {
                    Comment = "einam alaus",
                    Date = "01.01.01 19:00",
                    EventId = 1,
                    Location = "bare",
                    Title = "alus"
                };
                var model3 = new Group
                {
                    GroupId = 1,
                    Name = "Alus"
                };
                context.User.Add(model);
                context.Event.Add(model2);
                context.Group.Add(model3);
                context.SaveChanges();
                return Ok();
            }

        }


        // GET api/values
        public IEnumerable<string> Get()
        {
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
