using BaBookStudentai.Entities;

namespace BaBookStudentai.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BaBookStudentai.Models.BaBookDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BaBookStudentai.Models.BaBookDbContext context)
        {
            var group = new Group
            {
                GroupId = 1,
                Name = "Alus"
            };
            context.Group.Add(group);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
