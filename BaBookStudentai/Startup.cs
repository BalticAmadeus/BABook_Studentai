using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using BaBookStudentai.Models;
using BaBookStudentai.Entities;

[assembly: OwinStartup(typeof(BaBookStudentai.Startup))]

namespace BaBookStudentai
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            using (var db = new BaBookDbContext())
            {
                Group group = new Group
                {
                    Name = "Alus"

                };
                db.Group.Add(group);

                Event e1 = new Event { EventId = 0, GroupId = 0, CreatorId = 0, Date = DateTime.Now };
                Event e2 = new Event { EventId = 1, GroupId = 0, CreatorId = 0, Date = DateTime.Now };
                User u1 = new User { UserId = 0 };
                User u2 = new User { UserId = 1 };


                db.EventUser.Add(new EventUser
                {
                    EventId = 0,
                    Event = e1,
                    Status = AttendanceStatus.Going,
                    User = u1,
                    UserId = 0
                });

                db.EventUser.Add(new EventUser
                {
                    EventId = 0,
                    Event = e1,
                    Status = AttendanceStatus.NotAnswered,
                    User = u2,
                    UserId = 1
                });

                db.EventUser.Add(new EventUser
                {
                    EventId = 1,
                    Event = e2,
                    Status = AttendanceStatus.NotGoing,
                    User = u2,
                    UserId = 1
                });

                db.SaveChanges();
            }

        }
    }
}
