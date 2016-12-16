namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shippings", "CreateDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shippings", "CreateDate");
        }
    }
}
