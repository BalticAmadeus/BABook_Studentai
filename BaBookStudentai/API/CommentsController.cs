using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using BaBookStudentai.DTOs;
using BaBookStudentai.Entities;
using BaBookStudentai.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Security.Application;

//namespace BaBookStudentai.API
//{
//    [EnableCors("*", "*", "*")]
//    public class CommentsController : ApiController
//    {
//        private readonly BaBookDbContext _db = new BaBookDbContext();
//        //GET : api/comments/{eventId}
//        [System.Web.Http.HttpGet]
//        [System.Web.Http.Route("api/comments/{eventId}")]
//        public IHttpActionResult Get([FromUri]int eventId)
//        {
//            var commentators = _db.Event.SingleOrDefault(x => x.EventId == eventId)?.EventComments;
//            var comments = new List<EventCommentDto>();
            
//            foreach (var commentator in commentators)
//            {
                
//                var comment = new EventCommentDto
//                {
//                    Comment = commentator.UserComment,
//                    UserId = commentator.UserId

//                };
//                comment.Comment = Sanitizer.GetSafeHtmlFragment(comment.Comment);
//                comments.Add(comment);
//            }

//            return Ok(comments);
//        }

//        //POST : api/comments/{eventId}
//        [System.Web.Http.HttpPost]
//        [System.Web.Http.Route("api/comments/{eventId}")]
//        public IHttpActionResult Post([FromBody]EventCommentDto comment, [FromUri]int eventId)
//        {

//            var userId = User.Identity.GetUserId<int>();

//            var com = new EventComment
//            {
//                UserComment = comment.Comment,
//                UserId = userId
//            };

//            com.UserComment = Sanitizer.GetSafeHtmlFragment(com.UserComment);
//            _db.Event.Where(x => x.EventId == eventId).ToList().Find(x => x.EventId == eventId).EventComments.Add(com);
//            _db.SaveChanges();

//            return Ok();
//        }


//    }
//}
