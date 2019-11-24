namespace TwnData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
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
                "TWN.Purchase",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        MadeOn = c.DateTime(nullable: false),
                        Paid = c.Double(nullable: false),
                        MadeById = c.Int(nullable: false),
                        ThingId = c.Int(nullable: false),
                        HouseholdId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("TWN.AppUser", t => t.MadeById)
                .ForeignKey("TWN.Thing", t => t.ThingId)
                .ForeignKey("TWN.Households", t => t.HouseholdId)
                .Index(t => t.MadeById)
                .Index(t => t.ThingId)
                .Index(t => t.HouseholdId);
            
            CreateTable(
                "TWN.AppUser",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        FName = c.String(),
                        LName = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "TWN.Wish",
                c => new
                    {
                        WIshId = c.Int(nullable: false, identity: true),
                        MaxPrice = c.Double(nullable: false),
                        ExtraPay = c.Double(nullable: false),
                        MadeOn = c.DateTime(nullable: false),
                        BoughtOn = c.DateTime(),
                        Status = c.Byte(nullable: false),
                        MadeByUserId = c.Int(nullable: false),
                        GrantedByUserId = c.Int(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.WIshId)
                .ForeignKey("TWN.AppUser", t => t.GrantedByUserId)
                .ForeignKey("TWN.AppUser", t => t.MadeByUserId)
                .Index(t => t.MadeByUserId)
                .Index(t => t.GrantedByUserId);
            
            CreateTable(
                "TWN.Thing",
                c => new
                    {
                        ThingId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        HouseholdId = c.Int(nullable: false),
                        Needed = c.Boolean(nullable: false),
                        DefaultPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ThingId)
                .ForeignKey("TWN.Households", t => t.HouseholdId)
                .Index(t => t.HouseholdId);
            
            CreateTable(
                "dbo.HouseholdEntityUserEntities",
                c => new
                    {
                        HouseholdEntity_HouseholdId = c.Int(nullable: false),
                        UserEntity_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HouseholdEntity_HouseholdId, t.UserEntity_UserId })
                .ForeignKey("TWN.Households", t => t.HouseholdEntity_HouseholdId)
                .ForeignKey("TWN.AppUser", t => t.UserEntity_UserId)
                .Index(t => t.HouseholdEntity_HouseholdId)
                .Index(t => t.UserEntity_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HouseholdEntityUserEntities", "UserEntity_UserId", "TWN.AppUser");
            DropForeignKey("dbo.HouseholdEntityUserEntities", "HouseholdEntity_HouseholdId", "TWN.Households");
            DropForeignKey("TWN.Thing", "HouseholdId", "TWN.Households");
            DropForeignKey("TWN.Purchase", "HouseholdId", "TWN.Households");
            DropForeignKey("TWN.Purchase", "ThingId", "TWN.Thing");
            DropForeignKey("TWN.Purchase", "MadeById", "TWN.AppUser");
            DropForeignKey("TWN.Wish", "MadeByUserId", "TWN.AppUser");
            DropForeignKey("TWN.Wish", "GrantedByUserId", "TWN.AppUser");
            DropIndex("dbo.HouseholdEntityUserEntities", new[] { "UserEntity_UserId" });
            DropIndex("dbo.HouseholdEntityUserEntities", new[] { "HouseholdEntity_HouseholdId" });
            DropIndex("TWN.Thing", new[] { "HouseholdId" });
            DropIndex("TWN.Wish", new[] { "GrantedByUserId" });
            DropIndex("TWN.Wish", new[] { "MadeByUserId" });
            DropIndex("TWN.Purchase", new[] { "HouseholdId" });
            DropIndex("TWN.Purchase", new[] { "ThingId" });
            DropIndex("TWN.Purchase", new[] { "MadeById" });
            DropTable("dbo.HouseholdEntityUserEntities");
            DropTable("TWN.Thing");
            DropTable("TWN.Wish");
            DropTable("TWN.AppUser");
            DropTable("TWN.Purchase");
            DropTable("TWN.Households");
        }
    }
}
