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
        private BaBookDbContext _db = new BaBookDbContext();



        // GET api/testdata
        [Route("api/testdata")]
        public IEnumerable<string> Get()
        {
            List<EventComment> eventComments = new List<EventComment>();
            List<EventUser> eventUsers = new List<EventUser>();


            Group group = new Group
            {
                Name = "Alus",
                GroupId = 1
            };
            List<Group> groups = new List<Group>();
            groups.Add(group);
            _db.Group.Add(group);
            User user = new User
            {
                UserId = 1,
                UserGroups = groups,
                Username = "UserisNr1"
            };
            User user2 = new User
            {
                UserId = 2,
                UserGroups = groups,
                Username = "UserisNr2"
            };
            User user3 = new User
            {
                UserId = 3,
                UserGroups = groups,
                Username = "UserisNr3"
            };
            EventUser eventUser1 = new EventUser
            {
                EventId = 1,
                UserId = 2,
                Status = AttendanceStatus.Going
            };
            EventUser eventUser2 = new EventUser
            {
                EventId = 1,
                UserId = 3,
                Status = AttendanceStatus.Going
            };
            eventUsers.Add(eventUser1);
            eventUsers.Add(eventUser2);

            _db.User.Add(user);
            _db.User.Add(user2);
            _db.User.Add(user3);

            EventComment eventComment = new EventComment
            {
                UserComment = "hello event:)",
                UserId = 1
            };
            eventComments.Add(eventComment);
            Event @event = new Event
            {
                CreatorId = 1,
                Date = DateTime.Now,
                EventComments = eventComments,
                Comment = "isgerkime alaus",
                EventUsers = eventUsers,
                EventId = 1,
                GroupId = 1,
                Location = "Alaus namai",
                Title = "Po darbo einam alucio"
            };
            Event event2 = new Event
            {
                CreatorId = 1,
                Date = DateTime.Now,
                GroupId = 1,
                EventId = 2
            };
            _db.Event.Add(@event);
            _db.Event.Add(event2);
            _db.SaveChanges();
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


