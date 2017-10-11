using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaBookStudentai.Entities;

namespace BaBookStudentai.Models
{
    public class BaBookDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Event> Event { get; set; }
        public BaBookDbContext() : base("name=defaultConnection")
        {
         
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasMany<User>(x => x.AttendingUsers)
                .WithMany(x => x.UserEvents);
            modelBuilder.Entity<Group>()
                .HasMany<User>(x => x.GroupUsers)
                .WithMany(x => x.UserGroups);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
