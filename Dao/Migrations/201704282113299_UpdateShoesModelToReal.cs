namespace Dao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateShoesModelToReal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Shoes_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shoes", t => t.Shoes_Id)
                .Index(t => t.Shoes_Id);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Place",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Shoes", "OldId", c => c.Int(nullable: false));
            AddColumn("dbo.Shoes", "Notation", c => c.String());
            AddColumn("dbo.Shoes", "DateOfCreating", c => c.DateTime());
            AddColumn("dbo.Shoes", "NumberOfDuplication", c => c.Int(nullable: false));
            AddColumn("dbo.Shoes", "Shoes_Id", c => c.Long());
            AddColumn("dbo.Shoes", "Group_Id", c => c.Long());
            AddColumn("dbo.Shoes", "Material_Id", c => c.Long());
            AddColumn("dbo.Shoes", "PlaceOfBuying_Id", c => c.Long());
            AddColumn("dbo.Shoes", "PlaceOfProduce_Id", c => c.Long());
            CreateIndex("dbo.Shoes", "Shoes_Id");
            CreateIndex("dbo.Shoes", "Group_Id");
            CreateIndex("dbo.Shoes", "Material_Id");
            CreateIndex("dbo.Shoes", "PlaceOfBuying_Id");
            CreateIndex("dbo.Shoes", "PlaceOfProduce_Id");
            AddForeignKey("dbo.Shoes", "Shoes_Id", "dbo.Shoes", "Id");
            AddForeignKey("dbo.Shoes", "Group_Id", "dbo.Group", "Id");
            AddForeignKey("dbo.Shoes", "Material_Id", "dbo.Material", "Id");
            AddForeignKey("dbo.Shoes", "PlaceOfBuying_Id", "dbo.Place", "Id");
            AddForeignKey("dbo.Shoes", "PlaceOfProduce_Id", "dbo.Place", "Id");
            DropColumn("dbo.Shoes", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shoes", "Price", c => c.Long());
            DropForeignKey("dbo.Shoes", "PlaceOfProduce_Id", "dbo.Place");
            DropForeignKey("dbo.Shoes", "PlaceOfBuying_Id", "dbo.Place");
            DropForeignKey("dbo.Shoes", "Material_Id", "dbo.Material");
            DropForeignKey("dbo.Shoes", "Group_Id", "dbo.Group");
            DropForeignKey("dbo.Person", "Shoes_Id", "dbo.Shoes");
            DropForeignKey("dbo.Shoes", "Shoes_Id", "dbo.Shoes");
            DropIndex("dbo.Person", new[] { "Shoes_Id" });
            DropIndex("dbo.Shoes", new[] { "PlaceOfProduce_Id" });
            DropIndex("dbo.Shoes", new[] { "PlaceOfBuying_Id" });
            DropIndex("dbo.Shoes", new[] { "Material_Id" });
            DropIndex("dbo.Shoes", new[] { "Group_Id" });
            DropIndex("dbo.Shoes", new[] { "Shoes_Id" });
            DropColumn("dbo.Shoes", "PlaceOfProduce_Id");
            DropColumn("dbo.Shoes", "PlaceOfBuying_Id");
            DropColumn("dbo.Shoes", "Material_Id");
            DropColumn("dbo.Shoes", "Group_Id");
            DropColumn("dbo.Shoes", "Shoes_Id");
            DropColumn("dbo.Shoes", "NumberOfDuplication");
            DropColumn("dbo.Shoes", "DateOfCreating");
            DropColumn("dbo.Shoes", "Notation");
            DropColumn("dbo.Shoes", "OldId");
            DropTable("dbo.Place");
            DropTable("dbo.Material");
            DropTable("dbo.Group");
            DropTable("dbo.Person");
        }
    }
}
