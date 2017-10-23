using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using BaBookStudentai.DTOs;
using BaBookStudentai.Entities;
using BaBookStudentai.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Security.Application;

namespace BaBookStudentai.API
{
    [Authorize]
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
                comment.Comment = Sanitizer.GetSafeHtmlFragment(comment.Comment);
                comments.Add(comment);
            }

            return Ok(comments);
        }


        //POST : api/comments/{eventId}
        [HttpPost]
        [Route("api/comments/{eventId}")]
        public IHttpActionResult Post([FromBody]EventCommentDto comment, [FromUri]int eventId)
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            var com = new EventComment
            {
                UserComment = comment.Comment,
                UserId = userId
            };

            com.UserComment = Sanitizer.GetSafeHtmlFragment(com.UserComment);
            _db.Event.Where(x => x.EventId == eventId).ToList().Find(x => x.EventId == eventId).EventComments.Add(com);
            _db.SaveChanges();

            return Ok();
        }


    }
}
