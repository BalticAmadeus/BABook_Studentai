using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace BaBookStudentai.Models
{
    public class GroupModel
    {
        public List<UserEventModel> GroupEvents { get; set; } = new List<UserEventModel>();
        public List<UserModel> GroupUsers { get; set; }

        public string Name { get; set; } = "Alus";


        public void AddUser(UserModel user)
        {
            GroupUsers.Add(user);
        }

        public void AddEvent(UserEventModel userEvent)
        {
            GroupEvents.Add(userEvent);
        }

        
    }
}