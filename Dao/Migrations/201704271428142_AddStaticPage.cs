namespace Dao.Migrations
{
    using Dao.Model;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStaticPage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StaticPage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Html = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO dbo.StaticPage (Name, Type, Html) VALUES('О коллекции', " + (int)StaticPageType.AboutCollection + ", 'Коллекция собирается не первый год');");
            Sql("INSERT INTO dbo.StaticPage (Name, Type, Html) VALUES('О владелице', " + (int)StaticPageType.AboutAuthor + ", 'Пекрасный человек');");
        }
        
        public override void Down()
        {
            DropTable("dbo.StaticPage");
        }
    }
}
