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
    public class CommentsController : ApiController
    {
        private readonly BaBookDbContext _db = new BaBookDbContext();
        //GET : api/comments/{eventId}
        public IHttpActionResult Get(int id)
        {
            var eventComments = _db.Event.Where(x => x.EventId == id).Select(x => x.EventComments);
            return Ok(eventComments);
        }

        //POST : api/comments/{eventId}

        

        [HttpPost]
        [Route("api/comments/{eventId}")]
        public IHttpActionResult Post([FromBody]EventComment comment, [FromUri]int eventId)
        {

            //var userId = User.Identity.GetUserId();

            var com = new EventComment
            {
                UserComment = comment.UserComment,
                UserId = comment.UserId 
            };
            _db.Event.Where(x => x.EventId == eventId).ToList().Find(x => x.EventId == eventId).EventComments.Add(com);
            _db.SaveChanges();

            return Ok();        
        }


    }
}
