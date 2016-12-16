namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parts", "Document_Id", "dbo.Documents");
            DropIndex("dbo.Parts", new[] { "Document_Id" });
            DropColumn("dbo.Parts", "DocumentIdRef");
            RenameColumn(table: "dbo.Parts", name: "Document_Id", newName: "DocumentIdRef");
            AlterColumn("dbo.Parts", "DocumentIdRef", c => c.Int(nullable: true));
            CreateIndex("dbo.Parts", "DocumentIdRef");
            AddForeignKey("dbo.Parts", "DocumentIdRef", "dbo.Documents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "DocumentIdRef", "dbo.Documents");
            DropIndex("dbo.Parts", new[] { "DocumentIdRef" });
            AlterColumn("dbo.Parts", "DocumentIdRef", c => c.Int());
            RenameColumn(table: "dbo.Parts", name: "DocumentIdRef", newName: "Document_Id");
            AddColumn("dbo.Parts", "DocumentIdRef", c => c.Int(nullable: false));
            CreateIndex("dbo.Parts", "Document_Id");
            AddForeignKey("dbo.Parts", "Document_Id", "dbo.Documents", "Id");
        }
    }
}
