namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev131 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mails", "CreateDate", c => c.String());
            AlterColumn("dbo.Mails", "UserIdRef", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Mails", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Mails", "MailContent", c => c.String(nullable: false));
            AlterColumn("dbo.Mails", "IsSent", c => c.Int(nullable: false));
            DropColumn("dbo.Mails", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mails", "DateCreated", c => c.String());
            AlterColumn("dbo.Mails", "IsSent", c => c.Int());
            AlterColumn("dbo.Mails", "MailContent", c => c.String());
            AlterColumn("dbo.Mails", "Title", c => c.String());
            AlterColumn("dbo.Mails", "UserIdRef", c => c.String(maxLength: 128));
            DropColumn("dbo.Mails", "CreateDate");
        }
    }
}
