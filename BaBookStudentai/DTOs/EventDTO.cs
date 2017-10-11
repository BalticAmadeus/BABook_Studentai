using System;
using System.Collections.Generic;
using System.Linq;
using BaBookStudentai.Entities;

namespace BaBookStudentai.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public string Location { get; set; }

        internal static List<EventDto> Convert(IQueryable<Event> events)
        {
            return events.Select(e=> new EventDto()
            {
                Id = e.EventId,
                GroupId = e.GroupId,
                UserId = e.CreatorId,
                Title = e.Title,
                Date = e.Date,
                Comment = e.Comment,
                Location = e.Location
            }).ToList();
        }

        internal static EventDto Convert(Event e)
        {
            return new EventDto
            {
                Id = e.EventId,
                GroupId = e.GroupId,
                UserId = e.CreatorId,
                Title = e.Title,
                Date = e.Date,
                Comment = e.Comment,
                Location = e.Location
            };
        }
    }
}