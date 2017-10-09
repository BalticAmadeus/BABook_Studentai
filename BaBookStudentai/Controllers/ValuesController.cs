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
                context.User.Add(new User());
                context.Event.Add(new Event());
                context.Group.Add(new Group());
                context.GroupEvents.Add(new GroupEvents());
                context.EventParticipants.Add(new EventParticipants());
                context.GroupSubscribers.Add(new GroupSubscribers());
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
