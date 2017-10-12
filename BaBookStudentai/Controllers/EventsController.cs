using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BaBookStudentai.Entities;
using BaBookStudentai.Models;

namespace BaBookStudentai.Controllers
{
    //[Authorize]
    
    public class EventsController : ApiController
    {
        private BaBookDbContext db = new BaBookDbContext();


        public IHttpActionResult Get()
        {
            return Ok();
        }

        //// GET: api/events/{id}
        //[System.Web.Mvc.HttpGet]
        //[System.Web.Mvc.Route("api/events/{id}")]
        //public ActionResult EventDetails(int id)
        //{
        //    Event @event = db.Event.Find(id);
        //    if (@event == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return Json(@event, JsonRequestBehavior.AllowGet);
        //}

        //// POST: api/events
        //[System.Web.Mvc.HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateEvent(Event @event)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Event.Add(@event);
        //        db.SaveChanges();
        //        return new HttpStatusCodeResult(HttpStatusCode.OK);
        //    }
        //    return new HttpStatusCodeResult(HttpStatusCode.NotFound); 
        //}

    }
}
