namespace DBTilerElement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initLocationRename : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CalendarEvents", "myLocation_Id", "dbo.Location_Elements");
            DropIndex("dbo.CalendarEvents", new[] { "myLocation_Id" });
            DropColumn("dbo.CalendarEvents", "myLocation_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CalendarEvents", "myLocation_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CalendarEvents", "myLocation_Id");
            AddForeignKey("dbo.CalendarEvents", "myLocation_Id", "dbo.Location_Elements", "Id");
        }
    }
}
