using System.Linq;
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

        public UserEventController()
        {
            _eventUserRepository = new EventUserRepository();
        }

        // POST: api/userevent/{id}/{userId}/{status}
        [HttpPost]
        [Route("api/UserEvent/{eventId}/{userId}/{status}")]
        public IHttpActionResult Post(int eventId, int userId, int status)
        {
            var evUser = new EventUser
            {
                EventId = eventId,
                UserId = userId,
                Status = (AttendanceStatus)status
            };

            _db.EventUser.Add(evUser);
            _db.SaveChanges();

            return Ok();
        }

        // PUT: api/userevent/{id}/{userId}/{status}
        [HttpPut]
        [Route("api/UserEvent/{eventId}/{userId}/{status}")]
        public IHttpActionResult Put(int eventId, int userId, int status)
        {
            _db.EventUser.Where(x => x.EventId == eventId && x.UserId == userId)
                    .FirstOrDefault().Status = (AttendanceStatus)status;
            _db.SaveChanges();
            return Ok();
        }

        // GET: api/userevents/{eventId}
        [HttpGet]
        [Route("api/UserEvent/{eventId}")]
        public IHttpActionResult Get(int eventId)
        {
            var eventUsersRep = _eventUserRepository.Get();

            var eventUsersQuery = 
                from e in eventUsersRep
                where e.EventId == eventId
                select new EventUserDto
                {
                    EventId = e.EventId,
                    UserId = e.UserId,
                    Status = (int)e.Status
                };

            var eventUsers = eventUsersQuery.ToList();

            if (eventUsers.Any())
            {
                return Ok(eventUsers);
            }
            else
            {
                return BadRequest();
            }
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

}
