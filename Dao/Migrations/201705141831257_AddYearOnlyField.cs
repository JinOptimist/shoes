namespace Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYearOnlyField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shoes", "YearOfCreating", c => c.Int());
            AddColumn("dbo.Shoes", "YearOfPurchase", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shoes", "YearOfPurchase");
            DropColumn("dbo.Shoes", "YearOfCreating");
        }
    }
}
