namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "ImageLink", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "ImageLink", c => c.String());
        }
    }
}
