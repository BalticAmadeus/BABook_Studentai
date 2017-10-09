using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace BaBookStudentai.Entities
{
    public class Group
    {
        public List<Event> GroupEvents { get; set; }
        public List<User> GroupUsers { get; set; }

        public string Name { get; set; } = "Alus";


        public void AddUser(User user)
        {
            GroupUsers.Add(user);
        }

        public void AddEvent(Event event)
        {
            
        }

        
    }
}