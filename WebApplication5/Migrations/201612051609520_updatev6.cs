namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "ImageLink", c => c.String(nullable: false));
            AddColumn("dbo.Locations", "CreateDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "CreateDate");
            DropColumn("dbo.Parts", "ImageLink");
        }
    }
}
