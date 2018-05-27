namespace EventCalenderApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventDetails",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(),
                        EventStarTime = c.DateTime(nullable: false),
                        EventEndTime = c.DateTime(nullable: false),
                        EventMaxBookingTime = c.DateTime(nullable: false),
                        EventTypeId = c.Int(),
                        EventVenueId = c.Int(),
                        IsPublished = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        EventTypeId = c.Int(nullable: false, identity: true),
                        EventTypeName = c.String(),
                    })
                .PrimaryKey(t => t.EventTypeId);
            
            CreateTable(
                "dbo.EventVenues",
                c => new
                    {
                        EventVenueId = c.Int(nullable: false, identity: true),
                        EventVenueName = c.String(),
                    })
                .PrimaryKey(t => t.EventVenueId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventVenues");
            DropTable("dbo.EventTypes");
            DropTable("dbo.EventDetails");
        }
    }
}
