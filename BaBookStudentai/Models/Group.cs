using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace BaBookStudentai.Models
{
    public class Group
    {
        public List<UserEvent> GroupEvents { get; set; } = new List<UserEvent>();
        public List<User> GroupUsers { get; set; }

        public string Name { get; set; } = "Alus";


        public void AddUser(User user)
        {
            GroupUsers.Add(user);
        }

        public void AddEvent(UserEvent userEvent)
        {
            GroupEvents.Add(userEvent);
        }

        
    }
}