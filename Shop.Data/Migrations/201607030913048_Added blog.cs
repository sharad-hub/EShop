namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedblog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        BlogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        BlogContent = c.String(),
                        BlogImage = c.String(),
                        ViewCount = c.Int(nullable: false),
                        BlogCommentID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.CreatedByID, cascadeDelete: true)
                .Index(t => t.CreatedByID);
            
            CreateTable(
                "dbo.BlogLikes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LikedOn = c.DateTime(nullable: false),
                        LikedByID = c.Int(nullable: false),
                        BlogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.LikedByID, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .Index(t => t.LikedByID)
                .Index(t => t.BlogID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BlogCommentID = c.Int(),
                        CommentText = c.String(),
                        CommentedOn = c.DateTime(nullable: false),
                        CommentedByID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.CommentedByID, cascadeDelete: true)
                .ForeignKey("dbo.BlogComments", t => t.BlogCommentID)
                .Index(t => t.BlogCommentID)
                .Index(t => t.CommentedByID);
            
            CreateTable(
                "dbo.CategoriesToShows",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Products", "CategoriesToShowId", c => c.Int());
            CreateIndex("dbo.Products", "CategoriesToShowId");
            AddForeignKey("dbo.Products", "CategoriesToShowId", "dbo.CategoriesToShows", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoriesToShowId", "dbo.CategoriesToShows");
            DropForeignKey("dbo.Comments", "BlogCommentID", "dbo.BlogComments");
            DropForeignKey("dbo.Comments", "CommentedByID", "dbo.Users");
            DropForeignKey("dbo.BlogLikes", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.BlogLikes", "LikedByID", "dbo.Users");
            DropForeignKey("dbo.Blogs", "CreatedByID", "dbo.Users");
            DropForeignKey("dbo.BlogComments", "ID", "dbo.Blogs");
            DropIndex("dbo.Products", new[] { "CategoriesToShowId" });
            DropIndex("dbo.Comments", new[] { "CommentedByID" });
            DropIndex("dbo.Comments", new[] { "BlogCommentID" });
            DropIndex("dbo.BlogLikes", new[] { "BlogID" });
            DropIndex("dbo.BlogLikes", new[] { "LikedByID" });
            DropIndex("dbo.Blogs", new[] { "CreatedByID" });
            DropIndex("dbo.BlogComments", new[] { "ID" });
            DropColumn("dbo.Products", "CategoriesToShowId");
            DropTable("dbo.CategoriesToShows");
            DropTable("dbo.Comments");
            DropTable("dbo.BlogLikes");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogComments");
        }
    }
}
