namespace PostMeService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "User_userId" });
            CreateIndex("dbo.Comments", "user_userId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "user_userId" });
            CreateIndex("dbo.Comments", "User_userId");
        }
    }
}
