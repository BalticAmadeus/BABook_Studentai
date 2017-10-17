using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BaBookStudentai.DTOs;
using BaBookStudentai.Entities;
using BaBookStudentai.Models;

namespace BaBookStudentai.API
{
    [EnableCors("*", "*", "*")]
    public class CommentsController : ApiController
    {
        private readonly BaBookDbContext _db = new BaBookDbContext();
        //GET : api/comments/{eventId}
        [HttpGet]
        [Route("api/comments/{eventId}")]
        public IHttpActionResult Get([FromUri]int eventId)
        {
            var commentators = _db.Event.SingleOrDefault(x => x.EventId == eventId)?.EventComments;
            var comments = new List<EventCommentDto>();
            foreach (var commentator in commentators)
            {
                var comment = new EventCommentDto
                {
                    Comment = commentator.UserComment,
                    UserId = commentator.UserId

                };
                comments.Add(comment);
            }

            return Ok(comments);
        }

        //POST : api/comments/{eventId}



        [HttpPost]
        [Route("api/comments/{eventId}")]
        public IHttpActionResult Post([FromBody]EventCommentDto comment, [FromUri]int eventId)
        {

            //var userId = User.Identity.GetUserId();

            var com = new EventComment
            {
                UserComment = comment.Comment,
                UserId = comment.UserId
            };
            _db.Event.Where(x => x.EventId == eventId).ToList().Find(x => x.EventId == eventId).EventComments.Add(com);
            _db.SaveChanges();

            return Ok();
        }


    }
}
