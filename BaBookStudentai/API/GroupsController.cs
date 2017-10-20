using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using BaBookStudentai.DTOs;
using BaBookStudentai.Entities;
using BaBookStudentai.Models;
using Microsoft.Security.Application;
using Microsoft.AspNet.Identity;

namespace BaBookStudentai.API
{
    [EnableCors("*", "*", "*")]
    public class GroupsController : ApiController
    {
        private readonly GroupsRepository groupsRepository;

        public GroupsController()
        {
            groupsRepository = new GroupsRepository();
        }

        //System.Web.HttpContext.Current.User.Identity.GetUserId()


        [Authorize]
        [HttpGet]
        [Route("api/groups")]
        public IHttpActionResult Get()
        {
            var model = GroupDto.Convert(groupsRepository.Get());

            return Ok(model);
        }

        [HttpGet]
        [Route("api/groups/{id}")]
        public IHttpActionResult Get(int id)
        {
            var model = GroupDto.Convert(groupsRepository.Get()).SingleOrDefault();

            return Ok(model);
        }

        [HttpPost]
        [Route("api/groups")]
        public IHttpActionResult Post(GroupDto group)
        {
            groupsRepository.Post(group);

            return Ok();
        }

        [HttpPut]
        [Route("api/groups")]
        public IHttpActionResult Put(GroupDto group)
        {
            groupsRepository.Put(group);

            return Ok();
        }
    }

    public class GroupsRepository
    {
        private readonly BaBookDbContext _db = new BaBookDbContext();

        public IQueryable<Group> Get()
        {
            var groups = _db.Group;
            return groups;
        }

        public IQueryable<Group> GetById(int id)
        {
            var group = _db.Group.Where(x => x.GroupId == id);
            return group;
        }

        public void Post(GroupDto groupDto)
        {
            var group = new Group
            {
                Name = groupDto.Name
            };
            group.Name = Sanitizer.GetSafeHtmlFragment(group.Name);
            _db.Group.Add(group);
            _db.SaveChanges();
        }

        public void Put(GroupDto group)
        {
            _db.Group.Where(x => x.GroupId == group.GroupId).SingleOrDefault().Name = group.Name;
            _db.SaveChanges();
        }
    }
}
