using BaBookStudentai.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaBookStudentai.DTOs
{
    public class ParticipantsDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Status { get; set; }

        internal static List<ParticipantsDto> Convert(IQueryable<EventUser> participants)
        {
            return participants.Select(e => new ParticipantsDto()
            {
                Id = e.EventId,
                UserId = e.UserId,
                Status = (int)e.Status
            }).ToList();
        }

        internal static ParticipantsDto Convert(EventUser e)
        {
            return new ParticipantsDto
            {
                Id = e.EventId,
                UserId = e.UserId,
                Status = (int)e.Status
            };
        }


    }
}