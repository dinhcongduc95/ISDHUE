namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev17 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "User_Id" });
            DropColumn("dbo.ShoppingCarts", "UserIdRef");
            RenameColumn(table: "dbo.ShoppingCarts", name: "User_Id", newName: "UserIdRef");
            AlterColumn("dbo.ShoppingCarts", "UserIdRef", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ShoppingCarts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ShoppingCarts", "UserIdRef", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ShoppingCarts", "UserIdRef");
            AddForeignKey("dbo.ShoppingCarts", "UserIdRef", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "UserIdRef", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "UserIdRef" });
            AlterColumn("dbo.ShoppingCarts", "UserIdRef", c => c.String(maxLength: 128));
            AlterColumn("dbo.ShoppingCarts", "Name", c => c.String());
            AlterColumn("dbo.ShoppingCarts", "UserIdRef", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.ShoppingCarts", name: "UserIdRef", newName: "User_Id");
            AddColumn("dbo.ShoppingCarts", "UserIdRef", c => c.String(maxLength: 128));
            CreateIndex("dbo.ShoppingCarts", "User_Id");
            AddForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
