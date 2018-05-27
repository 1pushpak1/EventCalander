namespace EventCalenderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreign_key_added : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.EventDetails", "EventTypeId");
            CreateIndex("dbo.EventDetails", "EventVenueId");
            AddForeignKey("dbo.EventDetails", "EventTypeId", "dbo.EventTypes", "EventTypeId");
            AddForeignKey("dbo.EventDetails", "EventVenueId", "dbo.EventVenues", "EventVenueId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventDetails", "EventVenueId", "dbo.EventVenues");
            DropForeignKey("dbo.EventDetails", "EventTypeId", "dbo.EventTypes");
            DropIndex("dbo.EventDetails", new[] { "EventVenueId" });
            DropIndex("dbo.EventDetails", new[] { "EventTypeId" });
        }
    }
}
