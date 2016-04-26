namespace SeekARide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkedtripInfotorequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Request", "TripInformation_TripInformationId", c => c.Int());
            CreateIndex("dbo.Request", "TripInformation_TripInformationId");
            AddForeignKey("dbo.Request", "TripInformation_TripInformationId", "dbo.TripInformation", "TripInformationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "TripInformation_TripInformationId", "dbo.TripInformation");
            DropIndex("dbo.Request", new[] { "TripInformation_TripInformationId" });
            DropColumn("dbo.Request", "TripInformation_TripInformationId");
        }
    }
}
