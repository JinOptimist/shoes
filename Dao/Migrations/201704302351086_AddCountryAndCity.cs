namespace Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryAndCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Place", "CityName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Place", "CityName");
        }
    }
}
