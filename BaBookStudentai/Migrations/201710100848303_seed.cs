namespace BaBookStudentai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Location = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.EventParticipants",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventId, t.UserId });
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.GroupEvents",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.EventId });
            
            CreateTable(
                "dbo.GroupSubscribers",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.UserId });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.GroupSubscribers");
            DropTable("dbo.GroupEvents");
            DropTable("dbo.Groups");
            DropTable("dbo.EventParticipants");
            DropTable("dbo.Events");
        }
    }
}
