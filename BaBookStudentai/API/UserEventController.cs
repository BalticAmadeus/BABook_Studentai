using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaBookStudentai.DTOs;
using BaBookStudentai.Entities;
using BaBookStudentai.Models;

namespace BaBookStudentai.API
{
    public class UserEventController : ApiController
    {

        private readonly BaBookDbContext _db = new BaBookDbContext();
        private readonly EventUserRepository _eventUserRepository;
        private readonly UserRepository _userRepository;

        public UserEventController()
        {
            _eventUserRepository = new EventUserRepository();
            _userRepository = new UserRepository();
        }

        // POST: api/userevent
        [HttpPost]
        [Route("api/UserEvent")]
        public IHttpActionResult Post([FromBody]EventUserDto eventUser)
        {
            var evUser = new EventUser
            {
                EventId = eventUser.EventId,
                UserId = eventUser.UserId,
                Status = (AttendanceStatus)eventUser.Status
            };

            _db.EventUser.Add(evUser);
            _db.SaveChanges();

            return Ok();
        }

        // PUT: api/userevent
        [HttpPut]
        [Route("api/UserEvent")]
        public IHttpActionResult Put(EventUserDto eventUser)
        {
            _db.EventUser.Where(x => x.EventId == eventUser.EventId && x.UserId == eventUser.UserId)
                    .FirstOrDefault().Status = (AttendanceStatus)eventUser.Status;
            _db.SaveChanges();
            return Ok();
        }

        // GET: api/userevents/{eventId}
        [HttpGet]
        [Route("api/UserEvent/{eventId}")]
        public IHttpActionResult Get(int eventId)
        {
            var participatingUsers = _db.EventUser.Where(x => x.EventId == eventId).ToList();
            List<EventParticipantDto> participantList = new List<EventParticipantDto>();
            foreach (var participant in participatingUsers)
            {
                var eventParticipation = new EventParticipantDto
                {
                    Status = (int)participant.Status,
                    Name = _db.User.SingleOrDefault(x => x.UserId == participant.UserId)?.Username
                };
                participantList.Add(eventParticipation);
            }
           
            return Ok(participantList);
        }
    }

    public class EventUserRepository

       /* private readonly UserEventRepository _userEventRepository;

        public UserEventController()
        {
            _userEventRepository = new UserEventRepository();
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var events = _userEventRepository.Get();

            var model = UserEventDto.Convert(events);

            return Ok(model);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var participants = _userEventRepository.Get().Where(qq => qq.EventId == id);

            var model = UserEventDto.Convert(participants);

            if (participants != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }

       

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }*/

    //public class UserEventRepository

    {
        private readonly BaBookDbContext _db = new BaBookDbContext();

        public IQueryable<EventUser> Get()
        {

            var eventUsers = _db.EventUser;
            return eventUsers;
        }

    }

    public class UserRepository
    {
        private readonly BaBookDbContext _db = new BaBookDbContext();

        public IQueryable<User> Get()
        {

            var users = _db.User;
            return users;
        }
    }

}
/*
            return _db.EventUser;
        }

    }
}
*/
