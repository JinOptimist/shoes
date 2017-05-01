namespace Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onlyOneGiver : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "Shoes_Id", "dbo.Shoes");
            DropIndex("dbo.Person", new[] { "Shoes_Id" });
            AddColumn("dbo.Shoes", "Giver_Id", c => c.Long());
            CreateIndex("dbo.Shoes", "Giver_Id");
            AddForeignKey("dbo.Shoes", "Giver_Id", "dbo.Person", "Id");
            DropColumn("dbo.Person", "Shoes_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "Shoes_Id", c => c.Long());
            DropForeignKey("dbo.Shoes", "Giver_Id", "dbo.Person");
            DropIndex("dbo.Shoes", new[] { "Giver_Id" });
            DropColumn("dbo.Shoes", "Giver_Id");
            CreateIndex("dbo.Person", "Shoes_Id");
            AddForeignKey("dbo.Person", "Shoes_Id", "dbo.Shoes", "Id");
        }
    }
}
