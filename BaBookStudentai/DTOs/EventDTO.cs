using System;
using System.Collections.Generic;
using System.Linq;
using BaBookStudentai.Entities;
using Microsoft.AspNet.Identity;

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
            var userID = System.Web.HttpContext.Current.User.Identity.GetUserId();

            var list = new List<EventDto>();
            foreach (var @event in events)
            {
                var eventDto = new EventDto
                {
                    EventId = @event.EventId,
                    CreatorName = users.SingleOrDefault(x => x.Id.Equals(@event.CreatorId)).Nickname,
                    GroupName = groups.SingleOrDefault(x => x.GroupId.Equals(@event.GroupId)).Name,
                    Date = @event.Date,
                    Title = @event.Title,
                    Comment = @event.Comment,
                    Location = @event.Location,
                    Status = (int)eventUsers.SingleOrDefault((x) => ((x.UserId == userID) && (x.EventId == @event.EventId))).Status
                };
                list.Add(eventDto);
            }
            return list;
        }
    }
}