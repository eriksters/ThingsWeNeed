namespace ThingsWeNeed.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "TWN.Wish", name: "MadeById", newName: "UserId");
            RenameIndex(table: "TWN.Wish", name: "IX_MadeById", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "TWN.Wish", name: "IX_UserId", newName: "IX_MadeById");
            RenameColumn(table: "TWN.Wish", name: "UserId", newName: "MadeById");
        }
    }
}
