﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaBookStudentai.Entities;

namespace BaBookStudentai.Controllers
{
    public class EventController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("Event/{Id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        [HttpPut]
        [Route("Event")]
        // PUT api/<controller>/5
        public void Put(Event userEvent)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}