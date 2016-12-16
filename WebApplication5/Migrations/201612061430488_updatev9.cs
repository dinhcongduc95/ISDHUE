namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shippings", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Shippings", new[] { "Location_Id" });
            DropColumn("dbo.Shippings", "LocationIdRef");
            RenameColumn(table: "dbo.Shippings", name: "Location_Id", newName: "LocationIdRef");
            AlterColumn("dbo.Shippings", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Shippings", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Shippings", "PaymentType", c => c.String(nullable: false));
            AlterColumn("dbo.Shippings", "DeadLine", c => c.String(nullable: false));
            AlterColumn("dbo.Shippings", "PhoneNo", c => c.String(nullable: false));
            AlterColumn("dbo.Shippings", "LocationIdRef", c => c.Int(nullable: false));
            CreateIndex("dbo.Shippings", "LocationIdRef");
            AddForeignKey("dbo.Shippings", "LocationIdRef", "dbo.Locations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shippings", "LocationIdRef", "dbo.Locations");
            DropIndex("dbo.Shippings", new[] { "LocationIdRef" });
            AlterColumn("dbo.Shippings", "LocationIdRef", c => c.Int());
            AlterColumn("dbo.Shippings", "PhoneNo", c => c.String());
            AlterColumn("dbo.Shippings", "DeadLine", c => c.String());
            AlterColumn("dbo.Shippings", "PaymentType", c => c.String());
            AlterColumn("dbo.Shippings", "Description", c => c.String());
            AlterColumn("dbo.Shippings", "Name", c => c.String());
            RenameColumn(table: "dbo.Shippings", name: "LocationIdRef", newName: "Location_Id");
            AddColumn("dbo.Shippings", "LocationIdRef", c => c.Int(nullable: false));
            CreateIndex("dbo.Shippings", "Location_Id");
            AddForeignKey("dbo.Shippings", "Location_Id", "dbo.Locations", "Id");
        }
    }
}
