namespace MyStoryWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 30),
                        Description = c.String(maxLength: 100),
                        Content = c.String(),
                        PostedOn = c.DateTimeOffset(nullable: false, precision: 7),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoryGroups",
                c => new
                    {
                        Story_Id = c.Int(nullable: false),
                        Group_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Story_Id, t.Group_Id })
                .ForeignKey("dbo.Stories", t => t.Story_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .Index(t => t.Story_Id)
                .Index(t => t.Group_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stories", "UserId", "dbo.Users");
            DropForeignKey("dbo.StoryGroups", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.StoryGroups", "Story_Id", "dbo.Stories");
            DropIndex("dbo.Stories", new[] { "UserId" });
            DropIndex("dbo.StoryGroups", new[] { "Group_Id" });
            DropIndex("dbo.StoryGroups", new[] { "Story_Id" });
            DropTable("dbo.StoryGroups");
            DropTable("dbo.Users");
            DropTable("dbo.Stories");
            DropTable("dbo.Groups");
        }
    }
}
