namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "CreateDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "CreateDate", c => c.String(nullable: false));
        }
    }
}
