namespace DBTilerElement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initScheduleContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalendarEvents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ThirdPartyID = c.String(),
                        Rigid = c.Boolean(nullable: false),
                        Location_Id = c.String(maxLength: 128),
                        myLocation_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location_Elements", t => t.Location_Id)
                .ForeignKey("dbo.Location_Elements", t => t.myLocation_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.myLocation_Id);
            
            CreateTable(
                "dbo.Location_Elements",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Repetition",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCalendarEvents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ThirdPartyID = c.String(),
                        Location_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location_Elements", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        city = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Zip = c.String(),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        defaultLocation = c.Boolean(nullable: false),
                        isNullLocation = c.Boolean(nullable: false),
                        isVerified = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location_Elements", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "Id", "dbo.Location_Elements");
            DropForeignKey("dbo.SubCalendarEvents", "Location_Id", "dbo.Location_Elements");
            DropForeignKey("dbo.CalendarEvents", "myLocation_Id", "dbo.Location_Elements");
            DropForeignKey("dbo.CalendarEvents", "Location_Id", "dbo.Location_Elements");
            DropIndex("dbo.Locations", new[] { "Id" });
            DropIndex("dbo.SubCalendarEvents", new[] { "Location_Id" });
            DropIndex("dbo.CalendarEvents", new[] { "myLocation_Id" });
            DropIndex("dbo.CalendarEvents", new[] { "Location_Id" });
            DropTable("dbo.Locations");
            DropTable("dbo.SubCalendarEvents");
            DropTable("dbo.Repetition");
            DropTable("dbo.Location_Elements");
            DropTable("dbo.CalendarEvents");
        }
    }
}
