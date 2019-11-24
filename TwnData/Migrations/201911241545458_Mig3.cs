namespace TwnData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("TWN.Thing", "Show", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("TWN.Thing", "Show");
        }
    }
}
