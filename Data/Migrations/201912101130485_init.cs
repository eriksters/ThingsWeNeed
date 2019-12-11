namespace ThingsWeNeed.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TWN.Households",
                c => new
                    {
                        HouseholdId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address_Address1 = c.String(),
                        Address_Address2 = c.String(),
                        Address_City = c.String(),
                        Address_PostCode = c.String(),
                        Address_Country = c.String(),
                    })
                .PrimaryKey(t => t.HouseholdId);
            
            CreateTable(
                "TWN.Thing",
                c => new
                    {
                        ThingId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        HouseholdId = c.Int(nullable: false),
                        Show = c.Boolean(nullable: false),
                        Needed = c.Boolean(nullable: false),
                        DefaultPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ThingId)
                .ForeignKey("TWN.Households", t => t.HouseholdId, cascadeDelete: true)
                .Index(t => t.HouseholdId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FName = c.String(),
                        LName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.HouseholdEntityUserEntities",
                c => new
                    {
                        HouseholdEntity_HouseholdId = c.Int(nullable: false),
                        UserEntity_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.HouseholdEntity_HouseholdId, t.UserEntity_Id })
                .ForeignKey("TWN.Households", t => t.HouseholdEntity_HouseholdId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserEntity_Id, cascadeDelete: true)
                .Index(t => t.HouseholdEntity_HouseholdId)
                .Index(t => t.UserEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.HouseholdEntityUserEntities", "UserEntity_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.HouseholdEntityUserEntities", "HouseholdEntity_HouseholdId", "TWN.Households");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("TWN.Thing", "HouseholdId", "TWN.Households");
            DropIndex("dbo.HouseholdEntityUserEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.HouseholdEntityUserEntities", new[] { "HouseholdEntity_HouseholdId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("TWN.Thing", new[] { "HouseholdId" });
            DropTable("dbo.HouseholdEntityUserEntities");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("TWN.Thing");
            DropTable("TWN.Households");
        }
    }
}
