namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Payments", "Shipping_Id", "dbo.Shippings");
            DropForeignKey("dbo.Payments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Payments", new[] { "Product_Id" });
            DropIndex("dbo.Payments", new[] { "Shipping_Id" });
            DropIndex("dbo.Payments", new[] { "User_Id" });
            DropColumn("dbo.Payments", "ProductIdRef");
            DropColumn("dbo.Payments", "ShippingIdRef");
            DropColumn("dbo.Payments", "UserIdRef");
            RenameColumn(table: "dbo.Payments", name: "Product_Id", newName: "ProductIdRef");
            RenameColumn(table: "dbo.Payments", name: "Shipping_Id", newName: "ShippingIdRef");
            RenameColumn(table: "dbo.Payments", name: "User_Id", newName: "UserIdRef");
            AddColumn("dbo.Payments", "CreateDate", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "UserIdRef", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Payments", "Amount", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "Currency", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "IsPaid", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "ProductIdRef", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "ShippingIdRef", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "UserIdRef", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Payments", "UserIdRef");
            CreateIndex("dbo.Payments", "ProductIdRef");
            CreateIndex("dbo.Payments", "ShippingIdRef");
            AddForeignKey("dbo.Payments", "ProductIdRef", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "ShippingIdRef", "dbo.Shippings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "UserIdRef", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "UserIdRef", "dbo.AspNetUsers");
            DropForeignKey("dbo.Payments", "ShippingIdRef", "dbo.Shippings");
            DropForeignKey("dbo.Payments", "ProductIdRef", "dbo.Products");
            DropIndex("dbo.Payments", new[] { "ShippingIdRef" });
            DropIndex("dbo.Payments", new[] { "ProductIdRef" });
            DropIndex("dbo.Payments", new[] { "UserIdRef" });
            AlterColumn("dbo.Payments", "UserIdRef", c => c.String(maxLength: 128));
            AlterColumn("dbo.Payments", "ShippingIdRef", c => c.Int());
            AlterColumn("dbo.Payments", "ProductIdRef", c => c.Int());
            AlterColumn("dbo.Payments", "IsPaid", c => c.Int());
            AlterColumn("dbo.Payments", "Currency", c => c.String());
            AlterColumn("dbo.Payments", "Amount", c => c.String());
            AlterColumn("dbo.Payments", "UserIdRef", c => c.String(maxLength: 128));
            DropColumn("dbo.Payments", "CreateDate");
            RenameColumn(table: "dbo.Payments", name: "UserIdRef", newName: "User_Id");
            RenameColumn(table: "dbo.Payments", name: "ShippingIdRef", newName: "Shipping_Id");
            RenameColumn(table: "dbo.Payments", name: "ProductIdRef", newName: "Product_Id");
            AddColumn("dbo.Payments", "UserIdRef", c => c.String(maxLength: 128));
            AddColumn("dbo.Payments", "ShippingIdRef", c => c.Int(nullable: false));
            AddColumn("dbo.Payments", "ProductIdRef", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "User_Id");
            CreateIndex("dbo.Payments", "Shipping_Id");
            CreateIndex("dbo.Payments", "Product_Id");
            AddForeignKey("dbo.Payments", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Payments", "Shipping_Id", "dbo.Shippings", "Id");
            AddForeignKey("dbo.Payments", "Product_Id", "dbo.Products", "Id");
        }
    }
}
