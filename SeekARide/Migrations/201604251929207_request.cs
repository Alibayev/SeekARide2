namespace SeekARide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class request : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        To = c.String(),
                        From = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        Response = c.Int(nullable: false),
                        Owner_UserId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.User", t => t.Owner_UserId)
                .ForeignKey("dbo.User", t => t.User_UserId)
                .Index(t => t.Owner_UserId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "User_UserId", "dbo.User");
            DropForeignKey("dbo.Request", "Owner_UserId", "dbo.User");
            DropIndex("dbo.Request", new[] { "User_UserId" });
            DropIndex("dbo.Request", new[] { "Owner_UserId" });
            DropTable("dbo.Request");
        }
    }
}
