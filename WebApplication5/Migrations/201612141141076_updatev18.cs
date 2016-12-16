namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev18 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.CartProducts", new[] { "Product_Id" });
            DropColumn("dbo.CartProducts", "ProductIdRef");
            RenameColumn(table: "dbo.CartProducts", name: "Product_Id", newName: "ProductIdRef");
            RenameColumn(table: "dbo.CartProducts", name: "ShoppingCart_Id1", newName: "ShoppingCartIdRef");
            RenameIndex(table: "dbo.CartProducts", name: "IX_ShoppingCart_Id1", newName: "IX_ShoppingCartIdRef");
            AlterColumn("dbo.CartProducts", "ProductIdRef", c => c.Int(nullable: false));
            CreateIndex("dbo.CartProducts", "ProductIdRef");
            AddForeignKey("dbo.CartProducts", "ProductIdRef", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.CartProducts", "ShoppingCart_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartProducts", "ShoppingCart_Id", c => c.Int());
            DropForeignKey("dbo.CartProducts", "ProductIdRef", "dbo.Products");
            DropIndex("dbo.CartProducts", new[] { "ProductIdRef" });
            AlterColumn("dbo.CartProducts", "ProductIdRef", c => c.Int());
            RenameIndex(table: "dbo.CartProducts", name: "IX_ShoppingCartIdRef", newName: "IX_ShoppingCart_Id1");
            RenameColumn(table: "dbo.CartProducts", name: "ShoppingCartIdRef", newName: "ShoppingCart_Id1");
            RenameColumn(table: "dbo.CartProducts", name: "ProductIdRef", newName: "Product_Id");
            AddColumn("dbo.CartProducts", "ProductIdRef", c => c.Int(nullable: false));
            CreateIndex("dbo.CartProducts", "Product_Id");
            AddForeignKey("dbo.CartProducts", "Product_Id", "dbo.Products", "Id");
        }
    }
}
