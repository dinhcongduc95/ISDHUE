namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Description", c => c.String());
        }
    }
}
