namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductParts", "Part_Id", "dbo.Parts");
            DropIndex("dbo.ProductParts", new[] { "Part_Id" });
            DropColumn("dbo.ProductParts", "PartIdRef");
            RenameColumn(table: "dbo.ProductParts", name: "Product_Id1", newName: "ProductIdRef");
            RenameColumn(table: "dbo.ProductParts", name: "Part_Id", newName: "PartIdRef");
            RenameIndex(table: "dbo.ProductParts", name: "IX_Product_Id1", newName: "IX_ProductIdRef");
            AlterColumn("dbo.ProductParts", "PartIdRef", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductParts", "PartIdRef");
            AddForeignKey("dbo.ProductParts", "PartIdRef", "dbo.Parts", "Id", cascadeDelete: true);
            DropColumn("dbo.ProductParts", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductParts", "Product_Id", c => c.Int());
            DropForeignKey("dbo.ProductParts", "PartIdRef", "dbo.Parts");
            DropIndex("dbo.ProductParts", new[] { "PartIdRef" });
            AlterColumn("dbo.ProductParts", "PartIdRef", c => c.Int());
            RenameIndex(table: "dbo.ProductParts", name: "IX_ProductIdRef", newName: "IX_Product_Id1");
            RenameColumn(table: "dbo.ProductParts", name: "PartIdRef", newName: "Part_Id");
            RenameColumn(table: "dbo.ProductParts", name: "ProductIdRef", newName: "Product_Id1");
            AddColumn("dbo.ProductParts", "PartIdRef", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductParts", "Part_Id");
            AddForeignKey("dbo.ProductParts", "Part_Id", "dbo.Parts", "Id");
        }
    }
}
