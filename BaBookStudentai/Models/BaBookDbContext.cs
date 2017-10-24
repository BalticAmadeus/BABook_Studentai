using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaBookStudentai.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaBookStudentai.Models
{
    public class BaBookDbContext : IdentityDbContext<User>
    {
        public DbSet<Group> Group { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventUser> EventUser { get; set; }
        public DbSet<EventComment> EventComment { get; set; }

        public BaBookDbContext()
            : base("name=defaultConnection")
        {
        }

        public static BaBookDbContext Create()
        {
            return new BaBookDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Event>()
            //    .HasMany<User>(x => x.AttendingUsers)
            //    .WithMany(x => x.UserEvents);
            //modelBuilder.Entity<Group>()
            //    .HasMany<User>(x => x.GroupUsers)
            //    .WithMany(x => x.UserGroups);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Event>().HasKey(x => x.EventId);
            modelBuilder.Entity<EventUser>().HasKey(x =>
                new
                {
                    x.UserId,
                    x.EventId
                });
            //relationships
            modelBuilder.Entity<User>()
                .HasMany(x => x.EventUsers)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Event>()
                .HasMany(x => x.EventUsers)
                .WithRequired(x => x.Event)
                .HasForeignKey(x => x.EventId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
