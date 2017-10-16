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


        internal static List<EventDto> Convert(IQueryable<Event> events, IQueryable<Group> groups,
                                                IQueryable<EventUser> eventUsers, IQueryable<User> users)
        {
            var list = new List<EventDto>();
            foreach (var @event in events)
            {
                var eventDto = new EventDto
                {
                    Id = @event.EventId,
                    GroupName = groups.SingleOrDefault(x => x.GroupId == @event.GroupId)?.Name,
                    CreatorName = users.SingleOrDefault(x => x.UserId == @event.CreatorId)?.Username,
                    Title = @event.Title,
                    Date = @event.Date,
                    Comment = @event.Comment,
                    Location = @event.Location,
                    Status = (int)eventUsers.SingleOrDefault(x => x.UserId == 1).Status //TODO change current user id 

                };
                list.Add(eventDto);
            }
            return list;
        }
    }
}