namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newclassesaddedagain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        QuantityPerUnit = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        UnitsInStocks = c.Int(nullable: false),
                        UnitsOnOrders = c.Int(nullable: false),
                        Discounted = c.Int(nullable: false),
                        Category_CategoryId = c.Int(),
                        Suppliers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.Suppliers", t => t.Suppliers_Id)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.Suppliers_Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(maxLength: 50),
                        ContractName = c.String(),
                        ContractTitle = c.String(),
                        Addres = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        WebsiteURL = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CompanyName, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Suppliers_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Suppliers", new[] { "CompanyName" });
            DropIndex("dbo.Products", new[] { "Suppliers_Id" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
