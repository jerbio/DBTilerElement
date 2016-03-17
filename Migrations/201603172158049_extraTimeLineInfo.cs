namespace DBTilerElement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extraTimeLineInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "UserId", c => c.String());
            AddColumn("dbo.SubCalendarEvents", "Start", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "End", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "CalendarEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "CalendarStart", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "HumaneStart", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "HumaneEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "NonHumaneStart", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "NonHumaneEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubCalendarEvents", "NonHumaneEnd");
            DropColumn("dbo.SubCalendarEvents", "NonHumaneStart");
            DropColumn("dbo.SubCalendarEvents", "HumaneEnd");
            DropColumn("dbo.SubCalendarEvents", "HumaneStart");
            DropColumn("dbo.SubCalendarEvents", "CalendarStart");
            DropColumn("dbo.SubCalendarEvents", "CalendarEnd");
            DropColumn("dbo.SubCalendarEvents", "End");
            DropColumn("dbo.SubCalendarEvents", "Start");
            DropColumn("dbo.Locations", "UserId");
        }
    }
}
