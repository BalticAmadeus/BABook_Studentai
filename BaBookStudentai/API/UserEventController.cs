using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BaBookStudentai.DTOs;
using BaBookStudentai.Entities;
using BaBookStudentai.Models;

namespace BaBookStudentai.API
{
    [Authorize]
    [EnableCors("*", "*", "*")]
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
        public IHttpActionResult Post([FromBody] EventUserDto eventUser)
        {

            var evUser = new EventUser
            {
                EventId = eventUser.EventId,
                UserId = eventUser.UserId,
                Status = (AttendanceStatus)eventUser.Status
            };

            _db.EventUser.AddOrUpdate(evUser);
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
                    Name = _db.Users.SingleOrDefault(x => x.Id == participant.UserId)?.Email
                };
                participantList.Add(eventParticipation);
            }

            return Ok(participantList);
        }

    }

    public class EventUserRepository
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
            var users = _db.Users;
            return users;
        }
    }

}

