using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaBookStudentai.DTOs;
using BaBookStudentai.Entities;
using BaBookStudentai.Models;

namespace BaBookStudentai.API
{
    public class ParticipantsController : ApiController
    {
        private readonly ParticipantsRepository participantsRepository;

        public ParticipantsController()
        {
            participantsRepository = new ParticipantsRepository();
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var events = participantsRepository.Get();

            var model = ParticipantDto.Convert(events);

            return Ok(model);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var participants = participantsRepository.Get().Where(qq => qq.EventId == id);

            var model = ParticipantDto.Convert(participants);

            if (participants != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }

       

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class ParticipantsRepository
    {
        private readonly BaBookDbContext _db = new BaBookDbContext();

        public IQueryable<EventUser> Get()
        {
            return _db.EventUser;
        }

    }
}