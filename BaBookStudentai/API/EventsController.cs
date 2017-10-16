using System.Collections.Generic;
using System.Web.Http;
using BaBookStudentai.DTOs;
using BaBookStudentai.Models;
using System.Linq;
using BaBookStudentai.Entities;
using System.Net;
using Microsoft.AspNet.Identity;

namespace BaBookStudentai.API
{
    public class EventsController : ApiController
    {
        private readonly BaBookDbContext _db = new BaBookDbContext();
        private readonly EventsRepository eventsRepository;

        public EventsController()
        {
            eventsRepository = new EventsRepository();
        }

        // GET: api/events
        [HttpGet]
        [Route("api/events")]
        public IHttpActionResult Get()
        {
            var events = eventsRepository.GetEvents();
            var groups = eventsRepository.GetGroups();
            var users = eventsRepository.GetUsers();
            var eventUsers = eventsRepository.GetEventUsers();

            var model = EventDto.Convert(events, groups, eventUsers, users);

            return Ok(model);
        }

        // GET: api/events/{id}
        [HttpGet]
        [Route("api/events/{id}")]
        public IHttpActionResult Get([FromUri] int id)
        {
            var @event = eventsRepository.GetEvents().Where(x => x.EventId == id);
            var groups = eventsRepository.GetGroups();
            var users = eventsRepository.GetUsers();
            var eventUsers = eventsRepository.GetEventUsers();

            if (@event.Any())
            {
                var model = EventDto.Convert(@event, groups, eventUsers, users).SingleOrDefault();
                return Ok(model);
            }

            return NotFound();
        }

        // POST: api/events
        [HttpPost]
        [Route("api/events")]
        public IHttpActionResult Post(UserEventModel @event)
        {
            //var userId = User.Identity.GetUserId();

            var ev = new Event
            {
                EventUsers = new List<EventUser>(),
                CreatorId = @event.UserId,
                Comment = @event.Comment,
                Date = @event.Date,
                Location = @event.Location,
                GroupId = @event.GroupId,
                Title = @event.Title
            };

            _db.Event.Add(ev);
            _db.SaveChanges();

            return Ok();
        }

    }


    public class EventsRepository
    {
        private readonly BaBookDbContext _db = new BaBookDbContext();

        public IQueryable<Event> GetEvents()
        {
            var events = _db.Event;
            return events;
        }

        public IQueryable<User> GetUsers()
        {
            var users = _db.User;
            return users;
        }

        public IQueryable<Group> GetGroups()
        {
            var groups = _db.Group;
            return groups;
        }

        public IQueryable<EventUser> GetEventUsers()
        {
            var events = _db.EventUser;
            return events;
        }

    }
}
