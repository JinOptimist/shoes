namespace Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class combineOldIdUniq : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Shoes", new[] { "OldId" });
            AddColumn("dbo.Shoes", "OldIdLvl2", c => c.Int(nullable: false, defaultValue: 0));
            CreateIndex("dbo.Shoes", new[] { "OldId", "OldIdLvl2" }, unique: true, name: "IX_OldId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Shoes", "IX_OldId");
            DropColumn("dbo.Shoes", "OldIdLvl2");
            CreateIndex("dbo.Shoes", "OldId", unique: true);
        }
    }
}
