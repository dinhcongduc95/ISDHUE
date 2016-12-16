namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "IsPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "IsPaid", c => c.Int(nullable: false));
        }
    }
}
