using System;
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
        public IHttpActionResult Get()
        {
            var events = eventsRepository.Get();

            var model = EventDto.Convert(events);

            return Ok(model);

        }

        // GET: api/events/{id}
        public IHttpActionResult Get(int id)
        {
            var @event = eventsRepository.Get().ToList().Find(x => x.EventId == id);

            var model = EventDto.Convert(@event);

            if (@event != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/events
        public IHttpActionResult Post(UserEventModel @event)
        {
            //var userId = User.Identity.GetUserId();

            var ev = new Event
            {
                EventUsers = new List<EventUser>(),
                CreatorId = 1,
                Comment = @event.Comment,
                Date = @event.Date,
                Location = @event.Location,
                GroupId = 1,
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

        public IQueryable<Event> Get()
        {
            var events = _db.Event;
            return events;
        }

    }
}
