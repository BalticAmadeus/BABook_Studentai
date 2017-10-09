using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BaBookStudentai.Configuratios;
using BaBookStudentai.Entities;

namespace BaBookStudentai.Models
{
    public class BaBookDbContext : DbContext
    {
        public BaBookDbContext() : base("name=defaultConnection")
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventParticipants> EventParticipants { get; set; }
        public DbSet<GroupEvents> GroupEvents { get; set; }
        public DbSet<GroupSubscribers> GroupSubscribers { get; set; }


    }
}
