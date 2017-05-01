namespace Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oldIdIsUniq : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Shoes", "OldId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Shoes", new[] { "OldId" });
        }
    }
}
