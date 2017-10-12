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
    public class UserEventController : ApiController
    {
        private readonly UserEventRepository _userEventRepository;

        public UserEventController()
        {
            _userEventRepository = new UserEventRepository();
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var events = _userEventRepository.Get();

            var model = UserEventDto.Convert(events);

            return Ok(model);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var participants = _userEventRepository.Get().Where(qq => qq.EventId == id);

            var model = UserEventDto.Convert(participants);

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

    public class UserEventRepository
    {
        private readonly BaBookDbContext _db = new BaBookDbContext();

        public IQueryable<EventUser> Get()
        {
            return _db.EventUser;
        }

    }
}