namespace Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSecondLocation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shoes", "PlaceOfProduce_Id", "dbo.Place");
            DropIndex("dbo.Shoes", new[] { "PlaceOfProduce_Id" });
            DropColumn("dbo.Shoes", "PlaceOfProduce_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shoes", "PlaceOfProduce_Id", c => c.Long());
            CreateIndex("dbo.Shoes", "PlaceOfProduce_Id");
            AddForeignKey("dbo.Shoes", "PlaceOfProduce_Id", "dbo.Place", "Id");
        }
    }
}
