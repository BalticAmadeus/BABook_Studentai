using System;
using System.Collections.Generic;
using System.Linq;
using BaBookStudentai.Entities;

namespace BaBookStudentai.DTOs
{
    public class EventDto
    {
        public int EventId { get; set; }

        public string CreatorName { get; set; }

        public string GroupName { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public string Location { get; set; }

        public int Status { get; set; }


        internal static List<EventDto> Convert(IQueryable<Event> events, IQueryable<Group> groups,
                                                IQueryable<EventUser> eventUsers, IQueryable<User> users)
        {
            var list = new List<EventDto>();
            foreach (var @event in events)
            {
                var eventDto = new EventDto
                {
                    EventId = @event.EventId,
                    GroupName = groups.SingleOrDefault(x => x.GroupId.Equals(@event.GroupId)).Name,
                    CreatorName = users.SingleOrDefault(x => x.Id.Equals(@event.CreatorId)).Email,
                    Title = @event.Title,
                    Date = @event.Date,
                    Comment = @event.Comment,
                    Location = @event.Location,
                    Status = (int)eventUsers.FirstOrDefault(x => x.UserId.Equals(1)).Status
                };
                list.Add(eventDto);
            }
            return list;
        }
    }
}