using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaBookStudentai.Models;



namespace BaBookStudentai.Controllers
{
    public class EventController : ApiController
    {
        private static GroupModel alusGroup = new GroupModel(); // laikinai

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("Event/{Id}")]
        public UserEventModel Get(int id)
        {
            if (alusGroup.GroupEvents.Count > id)
                return alusGroup.GroupEvents[id];

            else return null;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        [HttpPut]
        [Route("Event")]
        // PUT api/<controller>/5
        public void Put(UserEventModel userEvent)
        {
            alusGroup.AddEvent(userEvent);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}