namespace ThingsWeNeed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Households",
                c => new
                    {
                        HouseholdId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.HouseholdId);
            
            CreateTable(
                "dbo.AppUsers",
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
                "dbo.Wishes",
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
                .ForeignKey("dbo.AppUsers", t => t.GrantedByUserId)
                .ForeignKey("dbo.AppUsers", t => t.MadeByUserId, cascadeDelete: false)
                .Index(t => t.MadeByUserId)
                .Index(t => t.GrantedByUserId);
            
            CreateTable(
                "dbo.Purchases",
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
                .ForeignKey("dbo.Things", t => t.ThingId, cascadeDelete: false)
                .ForeignKey("dbo.AppUsers", t => t.MadeById, cascadeDelete: false)
                .ForeignKey("dbo.Households", t => t.HouseholdId, cascadeDelete: false)
                .Index(t => t.MadeById)
                .Index(t => t.ThingId)
                .Index(t => t.HouseholdId);
            
            CreateTable(
                "dbo.Things",
                c => new
                    {
                        ThingId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        HouseholdId = c.Int(nullable: false),
                        Needed = c.Boolean(nullable: false),
                        DefaultPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ThingId)
                .ForeignKey("dbo.Households", t => t.HouseholdId, cascadeDelete: false)
                .Index(t => t.HouseholdId);
            
            CreateTable(
                "dbo.HouseholdAppUsers",
                c => new
                    {
                        Household_HouseholdId = c.Int(nullable: false),
                        AppUser_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Household_HouseholdId, t.AppUser_UserId })
                .ForeignKey("dbo.Households", t => t.Household_HouseholdId, cascadeDelete: false)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_UserId, cascadeDelete: false)
                .Index(t => t.Household_HouseholdId)
                .Index(t => t.AppUser_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Things", "HouseholdId", "dbo.Households");
            DropForeignKey("dbo.Purchases", "HouseholdId", "dbo.Households");
            DropForeignKey("dbo.HouseholdAppUsers", "AppUser_UserId", "dbo.AppUsers");
            DropForeignKey("dbo.HouseholdAppUsers", "Household_HouseholdId", "dbo.Households");
            DropForeignKey("dbo.Purchases", "MadeById", "dbo.AppUsers");
            DropForeignKey("dbo.Purchases", "ThingId", "dbo.Things");
            DropForeignKey("dbo.Wishes", "MadeByUserId", "dbo.AppUsers");
            DropForeignKey("dbo.Wishes", "GrantedByUserId", "dbo.AppUsers");
            DropIndex("dbo.HouseholdAppUsers", new[] { "AppUser_UserId" });
            DropIndex("dbo.HouseholdAppUsers", new[] { "Household_HouseholdId" });
            DropIndex("dbo.Things", new[] { "HouseholdId" });
            DropIndex("dbo.Purchases", new[] { "HouseholdId" });
            DropIndex("dbo.Purchases", new[] { "ThingId" });
            DropIndex("dbo.Purchases", new[] { "MadeById" });
            DropIndex("dbo.Wishes", new[] { "GrantedByUserId" });
            DropIndex("dbo.Wishes", new[] { "MadeByUserId" });
            DropTable("dbo.HouseholdAppUsers");
            DropTable("dbo.Things");
            DropTable("dbo.Purchases");
            DropTable("dbo.Wishes");
            DropTable("dbo.AppUsers");
            DropTable("dbo.Households");
        }
    }
}
