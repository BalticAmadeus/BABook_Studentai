using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaBookStudentai.Entities;

namespace BaBookStudentai.Controllers
{
    public class Invitation
    {
        public Event Event { get; set; }
        public User User { get; set; }

        public void AddToDb()
        {
            
        }
    }
    public class InvitationsController : ApiController
    {
        List<Invitation> invitations = new List<Invitation>();

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok();
        }


        // GET api/<controller>/5
        public Invitation Get(int id)
        {
            return invitations[id];
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post(int toUserId, int eventId)
        {
            invitations.Add(new Invitation { Event = new Event { EventId = eventId }, User = new User { UserId = toUserId } });
            return null;
        }

        //// PUT api/<controller>/5
        //public ActionResult Put(int toUserId, int eventId)
        //{
        //    invitations.Add(new Invitation { Event = new Event { EventId = eventId }, User = new User { UserId = toUserId } });
        //    return new HttpStatusCodeResult(HttpStatusCode.OK);
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}