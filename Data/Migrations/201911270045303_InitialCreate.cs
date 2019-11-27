namespace ThingsWeNeed.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                "TWN.AppUser",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        PenisSize = c.Single(nullable: false),
                        FName = c.String(),
                        LName = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.HouseholdEntityUserEntities",
                c => new
                    {
                        HouseholdEntity_HouseholdId = c.Int(nullable: false),
                        UserEntity_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HouseholdEntity_HouseholdId, t.UserEntity_UserId })
                .ForeignKey("TWN.Households", t => t.HouseholdEntity_HouseholdId, cascadeDelete: true)
                .ForeignKey("TWN.AppUser", t => t.UserEntity_UserId, cascadeDelete: true)
                .Index(t => t.HouseholdEntity_HouseholdId)
                .Index(t => t.UserEntity_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HouseholdEntityUserEntities", "UserEntity_UserId", "TWN.AppUser");
            DropForeignKey("dbo.HouseholdEntityUserEntities", "HouseholdEntity_HouseholdId", "TWN.Households");
            DropForeignKey("TWN.Thing", "HouseholdId", "TWN.Households");
            DropIndex("dbo.HouseholdEntityUserEntities", new[] { "UserEntity_UserId" });
            DropIndex("dbo.HouseholdEntityUserEntities", new[] { "HouseholdEntity_HouseholdId" });
            DropIndex("TWN.Thing", new[] { "HouseholdId" });
            DropTable("dbo.HouseholdEntityUserEntities");
            DropTable("TWN.AppUser");
            DropTable("TWN.Thing");
            DropTable("TWN.Households");
        }
    }
}
