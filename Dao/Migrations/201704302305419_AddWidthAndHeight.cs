namespace Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWidthAndHeight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shoes", "Width", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.Shoes", "Height", c => c.Int(nullable: false, defaultValue: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shoes", "Height");
            DropColumn("dbo.Shoes", "Width");
        }
    }
}
