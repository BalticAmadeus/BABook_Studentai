using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BaBookStudentai.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaBookStudentai.Entities
{
    public class User : IdentityUser
    { 
        //[Key]
        //public int UserId { get; set; }
        //public string Username { get; set; }
        public virtual List<Event> UserEvents { get; set; }
        public virtual List<Group> UserGroups { get; set; }
        public virtual List<EventUser> EventUsers { get; set; }
    }
}