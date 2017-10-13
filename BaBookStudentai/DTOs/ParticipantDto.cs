using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaBookStudentai.Entities;

namespace BaBookStudentai.DTOs
{
    public class ParticipantDto
    {
            public int UserId { get; set; }

            public int EventId { get; set; }

            public int Status { get; set; }

            internal static List<ParticipantDto> Convert(IQueryable<EventUser> eventUsers)
            {
                return eventUsers.Select(e => new ParticipantDto()
                {
                    UserId = e.UserId,
                    EventId = e.EventId,
                    Status = (int)e.Status
                }).ToList();
            }

            internal static ParticipantDto Convert(EventUser e)
            {
                return new ParticipantDto
                {
                    UserId = e.UserId,
                    EventId = e.EventId,
                    Status = (int)e.Status
                };
            }
        }
}