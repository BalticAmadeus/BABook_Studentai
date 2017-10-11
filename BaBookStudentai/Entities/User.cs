using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaBookStudentai.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        //public virtual List<Event> UserEvents { get; set; }
        public virtual List<Group> UserGroups { get; set; }
        public virtual List<EventUser> EventUsers { get; set; }
    }
}