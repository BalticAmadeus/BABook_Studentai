namespace BaBookStudentai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCreatorId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "CreatorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "CreatorId");
        }
    }
}
