namespace DBTilerElement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subcalendarEventfly : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "Id", "dbo.Location_Elements");
            DropIndex("dbo.Locations", new[] { "Id" });
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
                "dbo.NowProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        hasBeenSet = c.Boolean(),
                        BestStartTime = c.DateTimeOffset(precision: 7),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventNames",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MiscDatas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NoteData = c.String(),
                        SourceOfdata = c.Int(),
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
                        UndesiredStart = c.DateTimeOffset(precision: 7),
                        DesiredStart = c.DateTimeOffset(precision: 7),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.EventDisplays",
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
                "dbo.TilerUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        LastChange = c.DateTime(nullable: false),
                        ReferenceDay = c.DateTimeOffset(nullable: false, precision: 7),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        DB_SubCalendarEventRestricted_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubCalendarEvents", t => t.DB_SubCalendarEventRestricted_Id)
                .Index(t => t.DB_SubCalendarEventRestricted_Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        TilerUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TilerUsers", t => t.TilerUser_Id)
                .Index(t => t.TilerUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        TilerUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.TilerUsers", t => t.TilerUser_Id)
                .Index(t => t.TilerUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        TilerUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.TilerUsers", t => t.TilerUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.TilerUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.RestrictionProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
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
                .ForeignKey("dbo.RestrictionProfiles", t => t.RestrictionProfileId)
                .Index(t => t.RestrictionProfileId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TilerColors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TilerColors1", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.CalendarEvents", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.CalendarEvents", "Classification_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Location_Elements", "UserId", c => c.String());
            AddColumn("dbo.Location_Elements", "Address1", c => c.String());
            AddColumn("dbo.Location_Elements", "Address2", c => c.String());
            AddColumn("dbo.Location_Elements", "city", c => c.String());
            AddColumn("dbo.Location_Elements", "State", c => c.String());
            AddColumn("dbo.Location_Elements", "Country", c => c.String());
            AddColumn("dbo.Location_Elements", "Zip", c => c.String());
            AddColumn("dbo.Location_Elements", "Longitude", c => c.Double());
            AddColumn("dbo.Location_Elements", "Latitude", c => c.Double());
            AddColumn("dbo.Location_Elements", "defaultLocation", c => c.Boolean());
            AddColumn("dbo.Location_Elements", "isNullLocation", c => c.Boolean());
            AddColumn("dbo.Location_Elements", "isVerified", c => c.Boolean());
            AddColumn("dbo.Location_Elements", "Name", c => c.String());
            AddColumn("dbo.Location_Elements", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Repetition", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.SubCalendarEvents", "ConflictLevel", c => c.Int());
            AddColumn("dbo.SubCalendarEvents", "CreatorId", c => c.String());
            AddColumn("dbo.SubCalendarEvents", "InitializingStart", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.SubCalendarEvents", "isDeleted", c => c.Boolean());
            AddColumn("dbo.SubCalendarEvents", "isDeletedByUser", c => c.Boolean());
            AddColumn("dbo.SubCalendarEvents", "isRepeat", c => c.Boolean());
            AddColumn("dbo.SubCalendarEvents", "isRigid", c => c.Boolean());
            AddColumn("dbo.SubCalendarEvents", "Urgency", c => c.Int());
            AddColumn("dbo.SubCalendarEvents", "isDeviated", c => c.Boolean());
            AddColumn("dbo.SubCalendarEvents", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.SubCalendarEvents", "Classification_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.SubCalendarEvents", "conflict_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.SubCalendarEvents", "ProcrastinationProfile_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.SubCalendarEvents", "Restriction_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.SubCalendarEvents", "UIData_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.SubCalendarEvents", "CalendarEnd", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.SubCalendarEvents", "CalendarStart", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.SubCalendarEvents", "HumaneStart", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.SubCalendarEvents", "HumaneEnd", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.SubCalendarEvents", "NonHumaneStart", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.SubCalendarEvents", "NonHumaneEnd", c => c.DateTimeOffset(precision: 7));
            CreateIndex("dbo.CalendarEvents", "Classification_Id");
            CreateIndex("dbo.SubCalendarEvents", "Classification_Id");
            CreateIndex("dbo.SubCalendarEvents", "conflict_Id");
            CreateIndex("dbo.SubCalendarEvents", "ProcrastinationProfile_Id");
            CreateIndex("dbo.SubCalendarEvents", "Restriction_Id");
            CreateIndex("dbo.SubCalendarEvents", "UIData_Id");
            AddForeignKey("dbo.CalendarEvents", "Classification_Id", "dbo.Classifications", "Id");
            AddForeignKey("dbo.SubCalendarEvents", "Classification_Id", "dbo.Classifications", "Id");
            AddForeignKey("dbo.SubCalendarEvents", "conflict_Id", "dbo.ConflictProfiles", "Id");
            AddForeignKey("dbo.SubCalendarEvents", "ProcrastinationProfile_Id", "dbo.Procrastinations", "Id");
            AddForeignKey("dbo.SubCalendarEvents", "Restriction_Id", "dbo.RestrictionProfiles", "Id");
            AddForeignKey("dbo.SubCalendarEvents", "UIData_Id", "dbo.EventDisplays", "Id");
            DropColumn("dbo.CalendarEvents", "Rigid");
            DropTable("dbo.Locations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CalendarEvents", "Rigid", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.TilerColors", "Id", "dbo.TilerColors1");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.TilerUsers", "DB_SubCalendarEventRestricted_Id", "dbo.SubCalendarEvents");
            DropForeignKey("dbo.SubCalendarEvents", "UIData_Id", "dbo.EventDisplays");
            DropForeignKey("dbo.SubCalendarEvents", "Restriction_Id", "dbo.RestrictionProfiles");
            DropForeignKey("dbo.DB_RestrictionTimeLine", "RestrictionProfileId", "dbo.RestrictionProfiles");
            DropForeignKey("dbo.SubCalendarEvents", "ProcrastinationProfile_Id", "dbo.Procrastinations");
            DropForeignKey("dbo.SubCalendarEvents", "conflict_Id", "dbo.ConflictProfiles");
            DropForeignKey("dbo.IdentityUserRoles", "TilerUser_Id", "dbo.TilerUsers");
            DropForeignKey("dbo.IdentityUserLogins", "TilerUser_Id", "dbo.TilerUsers");
            DropForeignKey("dbo.IdentityUserClaims", "TilerUser_Id", "dbo.TilerUsers");
            DropForeignKey("dbo.EventDisplays", "UIColor_Id", "dbo.TilerColors1");
            DropForeignKey("dbo.SubCalendarEvents", "Classification_Id", "dbo.Classifications");
            DropForeignKey("dbo.CalendarEvents", "Classification_Id", "dbo.Classifications");
            DropIndex("dbo.TilerColors", new[] { "Id" });
            DropIndex("dbo.DB_RestrictionTimeLine", new[] { "RestrictionProfileId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "TilerUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "TilerUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "TilerUser_Id" });
            DropIndex("dbo.TilerUsers", new[] { "DB_SubCalendarEventRestricted_Id" });
            DropIndex("dbo.EventDisplays", new[] { "UIColor_Id" });
            DropIndex("dbo.SubCalendarEvents", new[] { "UIData_Id" });
            DropIndex("dbo.SubCalendarEvents", new[] { "Restriction_Id" });
            DropIndex("dbo.SubCalendarEvents", new[] { "ProcrastinationProfile_Id" });
            DropIndex("dbo.SubCalendarEvents", new[] { "conflict_Id" });
            DropIndex("dbo.SubCalendarEvents", new[] { "Classification_Id" });
            DropIndex("dbo.CalendarEvents", new[] { "Classification_Id" });
            AlterColumn("dbo.SubCalendarEvents", "NonHumaneEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.SubCalendarEvents", "NonHumaneStart", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.SubCalendarEvents", "HumaneEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.SubCalendarEvents", "HumaneStart", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.SubCalendarEvents", "CalendarStart", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.SubCalendarEvents", "CalendarEnd", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.SubCalendarEvents", "UIData_Id");
            DropColumn("dbo.SubCalendarEvents", "Restriction_Id");
            DropColumn("dbo.SubCalendarEvents", "ProcrastinationProfile_Id");
            DropColumn("dbo.SubCalendarEvents", "conflict_Id");
            DropColumn("dbo.SubCalendarEvents", "Classification_Id");
            DropColumn("dbo.SubCalendarEvents", "Discriminator");
            DropColumn("dbo.SubCalendarEvents", "isDeviated");
            DropColumn("dbo.SubCalendarEvents", "Urgency");
            DropColumn("dbo.SubCalendarEvents", "isRigid");
            DropColumn("dbo.SubCalendarEvents", "isRepeat");
            DropColumn("dbo.SubCalendarEvents", "isDeletedByUser");
            DropColumn("dbo.SubCalendarEvents", "isDeleted");
            DropColumn("dbo.SubCalendarEvents", "InitializingStart");
            DropColumn("dbo.SubCalendarEvents", "CreatorId");
            DropColumn("dbo.SubCalendarEvents", "ConflictLevel");
            DropColumn("dbo.Repetition", "Discriminator");
            DropColumn("dbo.Location_Elements", "Discriminator");
            DropColumn("dbo.Location_Elements", "Name");
            DropColumn("dbo.Location_Elements", "isVerified");
            DropColumn("dbo.Location_Elements", "isNullLocation");
            DropColumn("dbo.Location_Elements", "defaultLocation");
            DropColumn("dbo.Location_Elements", "Latitude");
            DropColumn("dbo.Location_Elements", "Longitude");
            DropColumn("dbo.Location_Elements", "Zip");
            DropColumn("dbo.Location_Elements", "Country");
            DropColumn("dbo.Location_Elements", "State");
            DropColumn("dbo.Location_Elements", "city");
            DropColumn("dbo.Location_Elements", "Address2");
            DropColumn("dbo.Location_Elements", "Address1");
            DropColumn("dbo.Location_Elements", "UserId");
            DropColumn("dbo.CalendarEvents", "Classification_Id");
            DropColumn("dbo.CalendarEvents", "Discriminator");
            DropTable("dbo.TilerColors");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.DB_RestrictionTimeLine");
            DropTable("dbo.RestrictionProfiles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.TilerUsers");
            DropTable("dbo.TilerColors1");
            DropTable("dbo.EventDisplays");
            DropTable("dbo.ConflictProfiles");
            DropTable("dbo.Procrastinations");
            DropTable("dbo.MiscDatas");
            DropTable("dbo.EventNames");
            DropTable("dbo.NowProfiles");
            DropTable("dbo.Classifications");
            CreateIndex("dbo.Locations", "Id");
            AddForeignKey("dbo.Locations", "Id", "dbo.Location_Elements", "Id");
        }
    }
}
