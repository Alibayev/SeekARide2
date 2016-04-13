namespace SeekARide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        State = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.TripInformation",
                c => new
                    {
                        TripInformationId = c.Int(nullable: false, identity: true),
                        Trip_TripId = c.Int(),
                    })
                .PrimaryKey(t => t.TripInformationId)
                .ForeignKey("dbo.Trip", t => t.Trip_TripId)
                .Index(t => t.Trip_TripId);
            
            CreateTable(
                "dbo.Trip",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        TravelDateTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        From_LocationId = c.Int(),
                        To_LocationId = c.Int(),
                    })
                .PrimaryKey(t => t.TripId)
                .ForeignKey("dbo.Location", t => t.From_LocationId)
                .ForeignKey("dbo.Location", t => t.To_LocationId)
                .Index(t => t.From_LocationId)
                .Index(t => t.To_LocationId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        CellPhone = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserTripInformation",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        TripInformation_TripInformationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.TripInformation_TripInformationId })
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.TripInformation", t => t.TripInformation_TripInformationId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.TripInformation_TripInformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTripInformation", "TripInformation_TripInformationId", "dbo.TripInformation");
            DropForeignKey("dbo.UserTripInformation", "User_UserId", "dbo.User");
            DropForeignKey("dbo.TripInformation", "Trip_TripId", "dbo.Trip");
            DropForeignKey("dbo.Trip", "To_LocationId", "dbo.Location");
            DropForeignKey("dbo.Trip", "From_LocationId", "dbo.Location");
            DropIndex("dbo.UserTripInformation", new[] { "TripInformation_TripInformationId" });
            DropIndex("dbo.UserTripInformation", new[] { "User_UserId" });
            DropIndex("dbo.Trip", new[] { "To_LocationId" });
            DropIndex("dbo.Trip", new[] { "From_LocationId" });
            DropIndex("dbo.TripInformation", new[] { "Trip_TripId" });
            DropTable("dbo.UserTripInformation");
            DropTable("dbo.User");
            DropTable("dbo.Trip");
            DropTable("dbo.TripInformation");
            DropTable("dbo.Location");
        }
    }
}
