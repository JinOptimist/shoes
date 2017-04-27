namespace Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shoes", "DateOfPurchase", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shoes", "DateOfPurchase", c => c.DateTime(nullable: false));
        }
    }
}
