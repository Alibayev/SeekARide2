namespace SeekARide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAddressBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressBook",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Location_LocationId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Location", t => t.Location_LocationId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Location_LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddressBook", "UserId", "dbo.User");
            DropForeignKey("dbo.AddressBook", "Location_LocationId", "dbo.Location");
            DropIndex("dbo.AddressBook", new[] { "Location_LocationId" });
            DropIndex("dbo.AddressBook", new[] { "UserId" });
            DropTable("dbo.AddressBook");
        }
    }
}
