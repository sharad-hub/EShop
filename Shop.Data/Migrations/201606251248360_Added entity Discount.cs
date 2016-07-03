namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedentityDiscount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinQuantity = c.Int(nullable: false),
                        PercentageDiscount = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Text = c.String(),
                        Summary = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductsDiscountMappings",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        DiscountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.DiscountID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Discounts", t => t.DiscountID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.DiscountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductsDiscountMappings", "DiscountID", "dbo.Discounts");
            DropForeignKey("dbo.ProductsDiscountMappings", "ProductID", "dbo.Products");
            DropIndex("dbo.ProductsDiscountMappings", new[] { "DiscountID" });
            DropIndex("dbo.ProductsDiscountMappings", new[] { "ProductID" });
            DropTable("dbo.ProductsDiscountMappings");
            DropTable("dbo.Discounts");
        }
    }
}
