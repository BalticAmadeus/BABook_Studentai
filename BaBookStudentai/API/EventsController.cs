using System.Collections.Generic;
using System.Web.Http;
using BaBookStudentai.DTOs;
using BaBookStudentai.Models;
using System.Linq;
using BaBookStudentai.Entities;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using Microsoft.Security.Application;


namespace BaBookStudentai.API
{
    [AllowAnonymous]
    [EnableCors("*", "*", "*")]
    public class EventsController : ApiController
    {
        private readonly BaBookDbContext _db = new BaBookDbContext();
        private readonly EventsRepository eventsRepository;

        public EventsController()
        {
            eventsRepository = new EventsRepository();
        }

        // GET: api/events/group/{groupId}
        [HttpGet]
        [Route("api/events/group/{groupId}")]
        public IHttpActionResult Get([FromUri] int groupId)
        {
            var events = eventsRepository.GetEvents(groupId);
            var groups = eventsRepository.GetGroups(groupId);
            var users = eventsRepository.GetUsers();
            var eventUsers = eventsRepository.GetEventUsers();

            var model = EventDto.Convert(events, groups, eventUsers, users);

            return Ok(model);
        }

        // GET: api/events
        [HttpGet]
        [Route("api/events")]
        public IHttpActionResult GetEvents()
        {
             var events = eventsRepository.GetAllEvents();
             var groups = eventsRepository.GetAllGroups();
             var users = eventsRepository.GetUsers();
             var eventUsers = eventsRepository.GetEventUsers();
             var model = EventDto.Convert(events, groups, eventUsers, users);
             return Ok(model);
        }


        //POST: api/events
        [HttpPost]
        [Route("api/events")]
        public IHttpActionResult Post(AddEventDto @event)
        {
            eventsRepository.PostNewEvent(@event);

            return Ok();
        }

    }


    public class EventsRepository
    {
        private readonly BaBookDbContext _db = new BaBookDbContext();

        public IQueryable<Event> GetEvents(int groupId)
        {
            IQueryable<Event> events = _db.Event.Where(x => x.GroupId == groupId);
            return events;
        }
        public IQueryable<Event> GetAllEvents()
        {
            IQueryable<Event> events = _db.Event;
            return events;
        }

        public IQueryable<User> GetUsers()
        {
            var users = _db.Users;
            return users;
        }

        public IQueryable<Group> GetGroups(int groupId)
        {
            IQueryable<Group> groups = _db.Group.Where(x => x.GroupId == groupId);
            return groups;
        }

        public IQueryable<Group> GetAllGroups()
        {
            IQueryable<Group> groups = _db.Group;
            return groups;
        }


        public IQueryable<EventUser> GetEventUsers()
        {
            var eventUsers = _db.EventUser;
            return eventUsers;
        }

        public void PostNewEvent(AddEventDto @event)
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            var ev = new Event
            {
                GroupId = @event.GroupId,
                Title = @event.Title,
                CreatorId = userId,
                Comment = @event.Comment,
                Date = @event.Date,
                Location = @event.Location                
            };

            ev.Comment = Sanitizer.GetSafeHtmlFragment(ev.Comment);
            ev.Title = Sanitizer.GetSafeHtmlFragment(ev.Title);
            ev.Location = Sanitizer.GetSafeHtmlFragment(ev.Location);

            _db.Event.Add(ev);
            _db.SaveChanges();
        }
    }
}
