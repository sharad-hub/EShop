namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTagAndLabel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductLabels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        OtherValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(),
                        IsValid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductsTagMappings",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ProductTagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.ProductTagID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.ProductTags", t => t.ProductTagID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.ProductTagID);
            
            AddColumn("dbo.Products", "ProductLabelId", c => c.Int());
            CreateIndex("dbo.Products", "ProductLabelId");
            AddForeignKey("dbo.Products", "ProductLabelId", "dbo.ProductLabels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductsTagMappings", "ProductTagID", "dbo.ProductTags");
            DropForeignKey("dbo.ProductsTagMappings", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductLabelId", "dbo.ProductLabels");
            DropIndex("dbo.ProductsTagMappings", new[] { "ProductTagID" });
            DropIndex("dbo.ProductsTagMappings", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "ProductLabelId" });
            DropColumn("dbo.Products", "ProductLabelId");
            DropTable("dbo.ProductsTagMappings");
            DropTable("dbo.ProductTags");
            DropTable("dbo.ProductLabels");
        }
    }
}
