namespace TwnData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WillySize : DbMigration
    {
        public override void Up()
        {
            AddColumn("TWN.AppUser", "PenisSize", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("TWN.AppUser", "PenisSize");
        }
    }
}
