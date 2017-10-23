using BaBookStudentai.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaBookStudentai.DTOs
{
    public class UserEventDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int Status { get; set; }

        internal static List<UserEventDto> Convert(IQueryable<EventUser> participants)
        {
            return participants.Select(e => new UserEventDto()
            {
                Id = e.EventId,
                UserId = e.UserId,
                Status = (int)e.Status
            }).ToList();
        }

        internal static UserEventDto Convert(EventUser e)
        {
            return new UserEventDto
            {
                Id = e.EventId,
                UserId = e.UserId,
                Status = (int)e.Status
            };
        }


    }
}