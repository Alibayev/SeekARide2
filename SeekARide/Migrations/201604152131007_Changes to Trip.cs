namespace SeekARide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangestoTrip : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TripInformation", "Trip_TripId", "dbo.Trip");
            DropForeignKey("dbo.UserTripInformation", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserTripInformation", "TripInformation_TripInformationId", "dbo.TripInformation");
            DropIndex("dbo.TripInformation", new[] { "Trip_TripId" });
            DropIndex("dbo.UserTripInformation", new[] { "User_UserId" });
            DropIndex("dbo.UserTripInformation", new[] { "TripInformation_TripInformationId" });
            AddColumn("dbo.TripInformation", "Capacity", c => c.Int(nullable: false));
            AddColumn("dbo.TripInformation", "User_UserId", c => c.Int());
            AddColumn("dbo.TripInformation", "Owner_UserId", c => c.Int());
            AddColumn("dbo.Trip", "TripInformation_TripInformationId", c => c.Int());
            AddColumn("dbo.User", "TripInformation_TripInformationId", c => c.Int());
            CreateIndex("dbo.TripInformation", "User_UserId");
            CreateIndex("dbo.TripInformation", "Owner_UserId");
            CreateIndex("dbo.User", "TripInformation_TripInformationId");
            CreateIndex("dbo.Trip", "TripInformation_TripInformationId");
            AddForeignKey("dbo.TripInformation", "User_UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.TripInformation", "Owner_UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.User", "TripInformation_TripInformationId", "dbo.TripInformation", "TripInformationId");
            AddForeignKey("dbo.Trip", "TripInformation_TripInformationId", "dbo.TripInformation", "TripInformationId");
            DropColumn("dbo.TripInformation", "Trip_TripId");
            DropTable("dbo.UserTripInformation");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserTripInformation",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        TripInformation_TripInformationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.TripInformation_TripInformationId });
            
            AddColumn("dbo.TripInformation", "Trip_TripId", c => c.Int());
            DropForeignKey("dbo.Trip", "TripInformation_TripInformationId", "dbo.TripInformation");
            DropForeignKey("dbo.User", "TripInformation_TripInformationId", "dbo.TripInformation");
            DropForeignKey("dbo.TripInformation", "Owner_UserId", "dbo.User");
            DropForeignKey("dbo.TripInformation", "User_UserId", "dbo.User");
            DropIndex("dbo.Trip", new[] { "TripInformation_TripInformationId" });
            DropIndex("dbo.User", new[] { "TripInformation_TripInformationId" });
            DropIndex("dbo.TripInformation", new[] { "Owner_UserId" });
            DropIndex("dbo.TripInformation", new[] { "User_UserId" });
            DropColumn("dbo.User", "TripInformation_TripInformationId");
            DropColumn("dbo.Trip", "TripInformation_TripInformationId");
            DropColumn("dbo.TripInformation", "Owner_UserId");
            DropColumn("dbo.TripInformation", "User_UserId");
            DropColumn("dbo.TripInformation", "Capacity");
            CreateIndex("dbo.UserTripInformation", "TripInformation_TripInformationId");
            CreateIndex("dbo.UserTripInformation", "User_UserId");
            CreateIndex("dbo.TripInformation", "Trip_TripId");
            AddForeignKey("dbo.UserTripInformation", "TripInformation_TripInformationId", "dbo.TripInformation", "TripInformationId", cascadeDelete: true);
            AddForeignKey("dbo.UserTripInformation", "User_UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.TripInformation", "Trip_TripId", "dbo.Trip", "TripId");
        }
    }
}
