namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mails", "IsSent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mails", "IsSent", c => c.Int(nullable: false));
        }
    }
}
