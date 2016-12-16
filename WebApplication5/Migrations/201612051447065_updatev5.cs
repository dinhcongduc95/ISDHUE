namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "CreateDate", c => c.String());
            AlterColumn("dbo.Documents", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Documents", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Documents", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "DateCreated", c => c.String());
            AlterColumn("dbo.Documents", "Description", c => c.String());
            AlterColumn("dbo.Documents", "Title", c => c.String());
            DropColumn("dbo.Documents", "CreateDate");
        }
    }
}
