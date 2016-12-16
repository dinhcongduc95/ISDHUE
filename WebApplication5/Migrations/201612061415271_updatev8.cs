namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "User_Id" });
            DropColumn("dbo.Reviews", "UserIdRef");
            RenameColumn(table: "dbo.Reviews", name: "User_Id", newName: "UserIdRef");
            AlterColumn("dbo.Reviews", "UserIdRef", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Reviews", "UserIdRef", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Reviews", "UserIdRef");
            AddForeignKey("dbo.Reviews", "UserIdRef", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UserIdRef", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "UserIdRef" });
            AlterColumn("dbo.Reviews", "UserIdRef", c => c.String(maxLength: 128));
            AlterColumn("dbo.Reviews", "UserIdRef", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Reviews", name: "UserIdRef", newName: "User_Id");
            AddColumn("dbo.Reviews", "UserIdRef", c => c.String(nullable: false));
            CreateIndex("dbo.Reviews", "User_Id");
            AddForeignKey("dbo.Reviews", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
