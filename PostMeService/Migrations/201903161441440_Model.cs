namespace PostMeService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        commentId = c.Int(nullable: false, identity: true),
                        time = c.DateTime(nullable: false),
                        description = c.String(),
                        upvotes = c.Int(nullable: false),
                        post_postId = c.Int(),
                        User_userId = c.Int(),
                    })
                .PrimaryKey(t => t.commentId)
                .ForeignKey("dbo.Posts", t => t.post_postId)
                .ForeignKey("dbo.Users", t => t.User_userId)
                .Index(t => t.post_postId)
                .Index(t => t.User_userId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        postId = c.Int(nullable: false, identity: true),
                        headline = c.String(),
                        description = c.String(),
                        time = c.DateTime(nullable: false),
                        upvotes = c.Int(nullable: false),
                        user_userId = c.Int(),
                    })
                .PrimaryKey(t => t.postId)
                .ForeignKey("dbo.Users", t => t.user_userId)
                .Index(t => t.user_userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "user_userId", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_userId", "dbo.Users");
            DropForeignKey("dbo.Comments", "post_postId", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "user_userId" });
            DropIndex("dbo.Comments", new[] { "User_userId" });
            DropIndex("dbo.Comments", new[] { "post_postId" });
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
