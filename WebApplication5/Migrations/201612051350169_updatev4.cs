namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Parts", "Origin", c => c.String(nullable: false));
            AlterColumn("dbo.Parts", "Manufacturer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parts", "Manufacturer", c => c.String());
            AlterColumn("dbo.Parts", "Origin", c => c.String());
            AlterColumn("dbo.Parts", "Name", c => c.String());
        }
    }
}
