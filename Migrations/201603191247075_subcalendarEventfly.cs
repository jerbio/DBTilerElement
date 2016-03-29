namespace DBTilerElement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subcalendarEventfly : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SubCalendarEvents", new[] { "Location_Id" });
            CreateTable(
                "dbo.EventNames",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classifications",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Placement = c.Int(nullable: false),
                        Succubus = c.Int(nullable: false),
                        LeisureType = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DB_SubCalendarEvent",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CalendarEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CalendarStart = c.DateTimeOffset(nullable: false, precision: 7),
                        ConflictLevel = c.Int(nullable: false),
                        CreatorId = c.String(),
                        HumaneEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        HumaneStart = c.DateTimeOffset(nullable: false, precision: 7),
                        InitializingStart = c.DateTimeOffset(nullable: false, precision: 7),
                        isDeleted = c.Boolean(nullable: false),
                        isDeletedByUser = c.Boolean(nullable: false),
                        isRepeat = c.Boolean(nullable: false),
                        isRigid = c.Boolean(nullable: false),
                        NonHumaneEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        NonHumaneStart = c.DateTimeOffset(nullable: false, precision: 7),
                        Urgency = c.Int(nullable: false),
                        isComplete = c.Boolean(nullable: false),
                        Score = c.Double(nullable: false),
                        Start = c.DateTimeOffset(nullable: false, precision: 7),
                        End = c.DateTimeOffset(nullable: false, precision: 7),
                        ThirdPartyID = c.String(),
                        Classification_Id = c.String(maxLength: 128),
                        conflict_Id = c.String(maxLength: 128),
                        Location_Id = c.String(maxLength: 128),
                        Name_Id = c.String(maxLength: 128),
                        Notes_Id = c.String(maxLength: 128),
                        ProcrastinationProfile_Id = c.String(maxLength: 128),
                        UIData_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classifications", t => t.Classification_Id)
                .ForeignKey("dbo.ConflictProfiles", t => t.conflict_Id)
                .ForeignKey("dbo.EventNames", t => t.Name_Id)
                .ForeignKey("dbo.MiscDatas", t => t.Notes_Id)
                .ForeignKey("dbo.Procrastinations", t => t.ProcrastinationProfile_Id)
                .ForeignKey("dbo.EventDisplay", t => t.UIData_Id)
                .Index(t => t.Classification_Id)
                .Index(t => t.conflict_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Name_Id)
                .Index(t => t.Notes_Id)
                .Index(t => t.ProcrastinationProfile_Id)
                .Index(t => t.UIData_Id);
            
            CreateTable(
                "dbo.ConflictProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ConflictType = c.Int(nullable: false),
                        ConflictCount = c.Int(nullable: false),
                        Flag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MiscDatas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Procrastinations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PreferredStartTime = c.DateTimeOffset(nullable: false, precision: 7),
                        DislikedStartTime = c.DateTimeOffset(nullable: false, precision: 7),
                        DislikedDaySection = c.Int(nullable: false),
                        UnwanteDaySection = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventDisplay",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        isVisible = c.Boolean(nullable: false),
                        isDefault = c.Int(nullable: false),
                        isCompleteUI = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        UIColor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TilerColors1", t => t.UIColor_Id)
                .Index(t => t.UIColor_Id);
            
            CreateTable(
                "dbo.TilerColors1",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        R = c.Int(nullable: false),
                        G = c.Int(nullable: false),
                        B = c.Int(nullable: false),
                        O = c.Double(nullable: false),
                        User = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DB_SubCalendarEventRestricted",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CalendarEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CalendarStart = c.DateTimeOffset(nullable: false, precision: 7),
                        ConflictLevel = c.Int(nullable: false),
                        CreatorId = c.String(),
                        HumaneEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        HumaneStart = c.DateTimeOffset(nullable: false, precision: 7),
                        InitializingStart = c.DateTimeOffset(nullable: false, precision: 7),
                        isDeleted = c.Boolean(nullable: false),
                        isDeletedByUser = c.Boolean(nullable: false),
                        isRepeat = c.Boolean(nullable: false),
                        isRigid = c.Boolean(nullable: false),
                        NonHumaneEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        NonHumaneStart = c.DateTimeOffset(nullable: false, precision: 7),
                        Urgency = c.Int(nullable: false),
                        isComplete = c.Boolean(nullable: false),
                        Score = c.Double(nullable: false),
                        Start = c.DateTimeOffset(nullable: false, precision: 7),
                        End = c.DateTimeOffset(nullable: false, precision: 7),
                        ThirdPartyID = c.String(),
                        Classification_Id = c.String(maxLength: 128),
                        conflict_Id = c.String(maxLength: 128),
                        Location_Id = c.String(maxLength: 128),
                        Name_Id = c.String(maxLength: 128),
                        Notes_Id = c.String(maxLength: 128),
                        ProcrastinationProfile_Id = c.String(maxLength: 128),
                        Restriction_Id = c.String(maxLength: 128),
                        UIData_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classifications", t => t.Classification_Id)
                .ForeignKey("dbo.ConflictProfiles", t => t.conflict_Id)
                .ForeignKey("dbo.Location_Elements", t => t.Location_Id)
                .ForeignKey("dbo.EventNames", t => t.Name_Id)
                .ForeignKey("dbo.MiscDatas", t => t.Notes_Id)
                .ForeignKey("dbo.Procrastinations", t => t.ProcrastinationProfile_Id)
                .ForeignKey("dbo.DB_RestrictionProfile", t => t.Restriction_Id)
                .ForeignKey("dbo.EventDisplay", t => t.UIData_Id)
                .Index(t => t.Classification_Id)
                .Index(t => t.conflict_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Name_Id)
                .Index(t => t.Notes_Id)
                .Index(t => t.ProcrastinationProfile_Id)
                .Index(t => t.Restriction_Id)
                .Index(t => t.UIData_Id);
            
            CreateTable(
                "dbo.DB_RestrictionProfile",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DB_RestrictionTimeLine",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RestrictionProfileId = c.String(maxLength: 128),
                        WeekDay = c.Int(nullable: false),
                        Start = c.DateTimeOffset(nullable: false, precision: 7),
                        End = c.DateTimeOffset(nullable: false, precision: 7),
                        Span = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DB_RestrictionProfile", t => t.RestrictionProfileId)
                .Index(t => t.RestrictionProfileId);
            
            CreateTable(
                "dbo.CalendarEventEventNames",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventNames", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ModifiedCalendarEventEventNames",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CalendarEventEventNames", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ModifiedSubCalendarEventEventNames",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CalendarEventEventNames", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.TilerColors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TilerColors1", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.CalendarEvents", "Classification_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.SubCalendarEvents", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.SubCalendarEvents", "UnmodifiedCalendarEventId", c => c.String());
            CreateIndex("dbo.CalendarEvents", "Classification_Id");
            CreateIndex("dbo.SubCalendarEvents", "Id");
            AddForeignKey("dbo.CalendarEvents", "Classification_Id", "dbo.Classifications", "Id");
            AddForeignKey("dbo.SubCalendarEvents", "Id", "dbo.DB_SubCalendarEvent", "Id");
            DropColumn("dbo.SubCalendarEvents", "Start");
            DropColumn("dbo.SubCalendarEvents", "End");
            DropColumn("dbo.SubCalendarEvents", "CalendarEnd");
            DropColumn("dbo.SubCalendarEvents", "CalendarStart");
            DropColumn("dbo.SubCalendarEvents", "HumaneStart");
            DropColumn("dbo.SubCalendarEvents", "HumaneEnd");
            DropColumn("dbo.SubCalendarEvents", "NonHumaneStart");
            DropColumn("dbo.SubCalendarEvents", "NonHumaneEnd");
            DropColumn("dbo.SubCalendarEvents", "ThirdPartyID");
            DropColumn("dbo.SubCalendarEvents", "Location_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubCalendarEvents", "Location_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.SubCalendarEvents", "ThirdPartyID", c => c.String());
            AddColumn("dbo.SubCalendarEvents", "NonHumaneEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "NonHumaneStart", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "HumaneEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "HumaneStart", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "CalendarStart", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "CalendarEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "End", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.SubCalendarEvents", "Start", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropForeignKey("dbo.TilerColors", "Id", "dbo.TilerColors1");
            DropForeignKey("dbo.ModifiedSubCalendarEventEventNames", "Id", "dbo.CalendarEventEventNames");
            DropForeignKey("dbo.SubCalendarEvents", "Id", "dbo.DB_SubCalendarEvent");
            DropForeignKey("dbo.ModifiedCalendarEventEventNames", "Id", "dbo.CalendarEventEventNames");
            DropForeignKey("dbo.CalendarEventEventNames", "Id", "dbo.EventNames");
            DropForeignKey("dbo.DB_SubCalendarEvent", "UIData_Id", "dbo.EventDisplay");
            DropForeignKey("dbo.DB_SubCalendarEvent", "ProcrastinationProfile_Id", "dbo.Procrastinations");
            DropForeignKey("dbo.DB_SubCalendarEvent", "Notes_Id", "dbo.MiscDatas");
            DropForeignKey("dbo.DB_SubCalendarEvent", "Name_Id", "dbo.EventNames");
            DropForeignKey("dbo.DB_SubCalendarEvent", "conflict_Id", "dbo.ConflictProfiles");
            DropForeignKey("dbo.DB_SubCalendarEvent", "Classification_Id", "dbo.Classifications");
            DropForeignKey("dbo.DB_SubCalendarEventRestricted", "UIData_Id", "dbo.EventDisplay");
            DropForeignKey("dbo.DB_SubCalendarEventRestricted", "Restriction_Id", "dbo.DB_RestrictionProfile");
            DropForeignKey("dbo.DB_RestrictionTimeLine", "RestrictionProfileId", "dbo.DB_RestrictionProfile");
            DropForeignKey("dbo.DB_SubCalendarEventRestricted", "ProcrastinationProfile_Id", "dbo.Procrastinations");
            DropForeignKey("dbo.DB_SubCalendarEventRestricted", "Notes_Id", "dbo.MiscDatas");
            DropForeignKey("dbo.DB_SubCalendarEventRestricted", "Name_Id", "dbo.EventNames");
            DropForeignKey("dbo.DB_SubCalendarEventRestricted", "Location_Id", "dbo.Location_Elements");
            DropForeignKey("dbo.DB_SubCalendarEventRestricted", "conflict_Id", "dbo.ConflictProfiles");
            DropForeignKey("dbo.DB_SubCalendarEventRestricted", "Classification_Id", "dbo.Classifications");
            DropForeignKey("dbo.EventDisplay", "UIColor_Id", "dbo.TilerColors1");
            DropForeignKey("dbo.CalendarEvents", "Classification_Id", "dbo.Classifications");
            DropIndex("dbo.TilerColors", new[] { "Id" });
            DropIndex("dbo.ModifiedSubCalendarEventEventNames", new[] { "Id" });
            DropIndex("dbo.SubCalendarEvents", new[] { "Id" });
            DropIndex("dbo.ModifiedCalendarEventEventNames", new[] { "Id" });
            DropIndex("dbo.CalendarEventEventNames", new[] { "Id" });
            DropIndex("dbo.DB_RestrictionTimeLine", new[] { "RestrictionProfileId" });
            DropIndex("dbo.DB_SubCalendarEventRestricted", new[] { "UIData_Id" });
            DropIndex("dbo.DB_SubCalendarEventRestricted", new[] { "Restriction_Id" });
            DropIndex("dbo.DB_SubCalendarEventRestricted", new[] { "ProcrastinationProfile_Id" });
            DropIndex("dbo.DB_SubCalendarEventRestricted", new[] { "Notes_Id" });
            DropIndex("dbo.DB_SubCalendarEventRestricted", new[] { "Name_Id" });
            DropIndex("dbo.DB_SubCalendarEventRestricted", new[] { "Location_Id" });
            DropIndex("dbo.DB_SubCalendarEventRestricted", new[] { "conflict_Id" });
            DropIndex("dbo.DB_SubCalendarEventRestricted", new[] { "Classification_Id" });
            DropIndex("dbo.EventDisplay", new[] { "UIColor_Id" });
            DropIndex("dbo.DB_SubCalendarEvent", new[] { "UIData_Id" });
            DropIndex("dbo.DB_SubCalendarEvent", new[] { "ProcrastinationProfile_Id" });
            DropIndex("dbo.DB_SubCalendarEvent", new[] { "Notes_Id" });
            DropIndex("dbo.DB_SubCalendarEvent", new[] { "Name_Id" });
            DropIndex("dbo.DB_SubCalendarEvent", new[] { "Location_Id" });
            DropIndex("dbo.DB_SubCalendarEvent", new[] { "conflict_Id" });
            DropIndex("dbo.DB_SubCalendarEvent", new[] { "Classification_Id" });
            DropIndex("dbo.CalendarEvents", new[] { "Classification_Id" });
            DropColumn("dbo.SubCalendarEvents", "UnmodifiedCalendarEventId");
            DropColumn("dbo.SubCalendarEvents", "Discriminator");
            DropColumn("dbo.CalendarEvents", "Classification_Id");
            DropTable("dbo.TilerColors");
            DropTable("dbo.ModifiedSubCalendarEventEventNames");
            DropTable("dbo.ModifiedCalendarEventEventNames");
            DropTable("dbo.CalendarEventEventNames");
            DropTable("dbo.DB_RestrictionTimeLine");
            DropTable("dbo.DB_RestrictionProfile");
            DropTable("dbo.DB_SubCalendarEventRestricted");
            DropTable("dbo.TilerColors1");
            DropTable("dbo.EventDisplay");
            DropTable("dbo.Procrastinations");
            DropTable("dbo.MiscDatas");
            DropTable("dbo.ConflictProfiles");
            DropTable("dbo.DB_SubCalendarEvent");
            DropTable("dbo.Classifications");
            DropTable("dbo.EventNames");
            CreateIndex("dbo.SubCalendarEvents", "Location_Id");
        }
    }
}
