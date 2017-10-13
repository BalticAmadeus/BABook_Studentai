using System;
using System.Collections.Generic;
using System.Linq;
using BaBookStudentai.Entities;

namespace BaBookStudentai.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }

        public string CreatorName { get; set; }

        public string GroupName { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public string Location { get; set; }

        public int Status { get; set; }

        internal static List<EventDto> Convert(IQueryable<Event> events)
        {
            return events.Select(e=> new EventDto()
            {
                Id = e.EventId,
                GroupName = "Alus",
                CreatorName = "vardenis",
                Title = e.Title,
                Date = e.Date,
                Comment = e.Comment,
                Location = e.Location,
                Status = 1
            }).ToList();
        }

        internal static EventDto Convert(Event e)
        {
            return new EventDto
            {
                Id = e.EventId,
                GroupName = "Alus",
                CreatorName = "vardenis",
                Title = e.Title,
                Date = e.Date,
                Comment = e.Comment,
                Location = e.Location,
                Status = 1
            };
        }
    }
}