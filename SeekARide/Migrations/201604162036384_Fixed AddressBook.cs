namespace SeekARide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedAddressBook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AddressBook", "Location_LocationId", "dbo.Location");
            DropIndex("dbo.AddressBook", new[] { "Location_LocationId" });
            AddColumn("dbo.Location", "AddressBook_UserId", c => c.Int());
            CreateIndex("dbo.Location", "AddressBook_UserId");
            AddForeignKey("dbo.Location", "AddressBook_UserId", "dbo.AddressBook", "UserId");
            DropColumn("dbo.AddressBook", "Location_LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AddressBook", "Location_LocationId", c => c.Int());
            DropForeignKey("dbo.Location", "AddressBook_UserId", "dbo.AddressBook");
            DropIndex("dbo.Location", new[] { "AddressBook_UserId" });
            DropColumn("dbo.Location", "AddressBook_UserId");
            CreateIndex("dbo.AddressBook", "Location_LocationId");
            AddForeignKey("dbo.AddressBook", "Location_LocationId", "dbo.Location", "LocationId");
        }
    }
}
