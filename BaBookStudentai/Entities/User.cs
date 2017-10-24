using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaBookStudentai.Entities
{
    public class User : IdentityUser
    { 
        public string Nickname { get; set; }

        public virtual List<Event> UserEvents { get; set; }
        public virtual List<Group> UserGroups { get; set; }
        public virtual List<EventUser> EventUsers { get; set; }
    }
}