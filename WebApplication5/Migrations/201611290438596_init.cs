namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductIdRef = c.Int(nullable: false),
                        ShoppingCart_Id = c.Int(),
                        Product_Id = c.Int(),
                        ShoppingCart_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCart_Id1)
                .Index(t => t.Product_Id)
                .Index(t => t.ShoppingCart_Id1);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Origin = c.String(),
                        CreateDate = c.String(),
                        ImageLink = c.String(),
                        CategoryIdRef = c.Int(nullable: false),
                        DocumentIdRef = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryIdRef, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.DocumentIdRef, cascadeDelete: true)
                .Index(t => t.CategoryIdRef)
                .Index(t => t.DocumentIdRef);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        CreateDate = c.String(),
                        ImageLink = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        DateCreated = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Origin = c.String(),
                        Manufacturer = c.String(),
                        CreateDate = c.String(),
                        DocumentIdRef = c.Int(nullable: false),
                        Document_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.Document_Id)
                .Index(t => t.Document_Id);
            
            CreateTable(
                "dbo.ProductParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartIdRef = c.Int(nullable: false),
                        Product_Id = c.Int(),
                        Part_Id = c.Int(),
                        Product_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.Part_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id1)
                .Index(t => t.Part_Id)
                .Index(t => t.Product_Id1);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserIdRef = c.String(maxLength: 128),
                        ProductIdRef = c.Int(nullable: false),
                        ShippingIdRef = c.Int(nullable: false),
                        Amount = c.String(),
                        Currency = c.String(),
                        IsPaid = c.Int(),
                        Product_Id = c.Int(),
                        Shipping_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Shippings", t => t.Shipping_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Shipping_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Shippings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationIdRef = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        PaymentType = c.String(),
                        DeadLine = c.String(),
                        PhoneNo = c.String(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PostalCode = c.String(),
                        Shippable = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductIdRef = c.Int(nullable: false),
                        Description = c.String(),
                        Point = c.Int(nullable: false),
                        CreateDate = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductIdRef, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.ProductIdRef)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserIdRef = c.String(maxLength: 128),
                        Name = c.String(),
                        CreateDate = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Mails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserIdRef = c.String(maxLength: 128),
                        Title = c.String(),
                        Description = c.String(),
                        MailContent = c.String(),
                        DateCreated = c.String(),
                        IsSent = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Mails", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CartProducts", "ShoppingCart_Id1", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Reviews", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "ProductIdRef", "dbo.Products");
            DropForeignKey("dbo.Payments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Payments", "Shipping_Id", "dbo.Shippings");
            DropForeignKey("dbo.Shippings", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Payments", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "DocumentIdRef", "dbo.Documents");
            DropForeignKey("dbo.ProductParts", "Product_Id1", "dbo.Products");
            DropForeignKey("dbo.ProductParts", "Part_Id", "dbo.Parts");
            DropForeignKey("dbo.Parts", "Document_Id", "dbo.Documents");
            DropForeignKey("dbo.Products", "CategoryIdRef", "dbo.Categories");
            DropForeignKey("dbo.CartProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Mails", new[] { "User_Id" });
            DropIndex("dbo.ShoppingCarts", new[] { "User_Id" });
            DropIndex("dbo.Reviews", new[] { "User_Id" });
            DropIndex("dbo.Reviews", new[] { "ProductIdRef" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Shippings", new[] { "Location_Id" });
            DropIndex("dbo.Payments", new[] { "User_Id" });
            DropIndex("dbo.Payments", new[] { "Shipping_Id" });
            DropIndex("dbo.Payments", new[] { "Product_Id" });
            DropIndex("dbo.ProductParts", new[] { "Product_Id1" });
            DropIndex("dbo.ProductParts", new[] { "Part_Id" });
            DropIndex("dbo.Parts", new[] { "Document_Id" });
            DropIndex("dbo.Products", new[] { "DocumentIdRef" });
            DropIndex("dbo.Products", new[] { "CategoryIdRef" });
            DropIndex("dbo.CartProducts", new[] { "ShoppingCart_Id1" });
            DropIndex("dbo.CartProducts", new[] { "Product_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Mails");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.Reviews");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Locations");
            DropTable("dbo.Shippings");
            DropTable("dbo.Payments");
            DropTable("dbo.ProductParts");
            DropTable("dbo.Parts");
            DropTable("dbo.Documents");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.CartProducts");
        }
    }
}
