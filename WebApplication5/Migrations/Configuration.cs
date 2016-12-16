using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication5.Models;

namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication5.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebApplication5.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //if (!context.Roles.Any(role => role.Name == "SuperAdmin"))
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    roleManager.Create(new IdentityRole("SuperAdmin"));
            //}
            //if (!context.Roles.Any(role => role.Name == "Admin"))
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    roleManager.Create(new IdentityRole("Admin"));
            //}

            //if (!context.Users.Any(user => user.UserName == "admin@admin.com"))
            //{
            //    var UserManagerFactory = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //    var user = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };
            //    var result = UserManagerFactory.Create(user, "admin123");
            //    UserManagerFactory.AddToRole(user.Id, "Admin");
            //}

            //context.Categories.AddOrUpdate(
            //    c => c.Code,
            //    new Category
            //    {
            //        CreateDate = DateTime.Now.ToShortDateString(),
            //        Code = "MAT21",
            //        Description = "Khong co",
            //        Name = "ghế",
            //        ImageLink = "chair1.jpg"
            //    },
            //    new Category
            //    {
            //        CreateDate = DateTime.Now.ToShortDateString(),
            //        Code = "MAT22",
            //        Description = "Khong co",
            //        Name = "bàn",
            //        ImageLink = "chair2.jpg"
            //    },
            //    new Category
            //    {
            //        CreateDate = DateTime.Now.ToShortDateString(),
            //        Code = "MAT23",
            //        Description = "Khong co",
            //        Name = "ghế băng",
            //        ImageLink = "chair3.jpg"
            //    },
            //    new Category
            //    {
            //        CreateDate = DateTime.Now.ToShortDateString(),
            //        Code = "MAT24",
            //        Description = "Khong co",
            //        Name = "ghế dài",
            //        ImageLink = "table1.jpg"
            //    }

            //    );
            //context.Documents.AddOrUpdate(
            //    d => d.Description,
            //    new Document
            //    {
            //        Description = "Giới thiệu 1",
            //        DateCreated = DateTime.Now.ToShortDateString(),
            //        Title = "Tài liệu 1"
            //    },
            //    new Document
            //    {
            //        Description = "Giới thiệu 2",
            //        DateCreated = DateTime.Now.ToShortDateString(),
            //        Title = "Tài liệu 2"
            //    },
            //    new Document
            //    {
            //        Description = "Giới thiệu 3",
            //        DateCreated = DateTime.Now.ToShortDateString(),
            //        Title = "Tài liệu 3"
            //    },
            //    new Document
            //    {
            //        Description = "Giới thiệu 4",
            //        DateCreated = DateTime.Now.ToShortDateString(),
            //        Title = "Tài liệu 4"
            //    }
            //    );
            


            //    context.Products.AddOrUpdate(
            //        p => p.Name,
            //        new Product
            //        {
            //            CreateDate = DateTime.Now.ToShortDateString(),
            //            Name = "Sản phẩm 1",
            //            Description = "Mô tả sản phẩm 1",
            //            CategoryIdRef = 1,
            //            DocumentIdRef = 1,
            //            ImageLink = "chair1.jpg",
            //            Origin = "Nguồn gốc 1",
            //            Price = 12
            //        },
            //        new Product
            //        {
            //            CreateDate = DateTime.Now.ToShortDateString(),
            //            Name = "Sản phẩm 2",
            //            Description = "Mô tả sản phẩm 2",
            //            CategoryIdRef = 2,
            //            DocumentIdRef = 2,
            //            ImageLink = "chair2.jpg",
            //            Origin = "Nguồn gốc 2",
            //            Price = 13
            //        },
            //        new Product
            //        {
            //            CreateDate = DateTime.Now.ToShortDateString(),
            //            Name = "Sản phẩm 3",
            //            Description = "Mô tả sản phẩm 3",
            //            CategoryIdRef = 3,
            //            DocumentIdRef = 3,
            //            ImageLink = "chair3.jpg",
            //            Origin = "Nguồn gốc 3",
            //            Price = 15
            //        },
            //        new Product
            //        {
            //            CreateDate = DateTime.Now.ToShortDateString(),
            //            Name = "Sản phẩm 4",
            //            Description = "Mô tả sản phẩm 4",
            //            CategoryIdRef = 4,
            //            DocumentIdRef = 4,
            //            ImageLink = "table1.jpg",
            //            Origin = "Nguồn gốc 4",
            //            Price = 16
            //        },
            //        new Product
            //        {
            //            CreateDate = DateTime.Now.ToShortDateString(),
            //            Name = "Sản phẩm 4",
            //            Description = "Mô tả sản phẩm 4",
            //            CategoryIdRef = 4,
            //            DocumentIdRef = 4,
            //            ImageLink = "table2.jpg",
            //            Origin = "Nguồn gốc 4",
            //            Price = 16
            //        },
            //        new Product
            //        {
            //            CreateDate = DateTime.Now.ToShortDateString(),
            //            Name = "Sản phẩm 4",
            //            Description = "Mô tả sản phẩm 4",
            //            CategoryIdRef = 4,
            //            DocumentIdRef = 4,
            //            ImageLink = "table3.jpg",
            //            Origin = "Nguồn gốc 4",
            //            Price = 16
            //        }
            //        );
            //    context.Reviews.AddOrUpdate(
            //        r => r.Id,
            //        new Review
            //        {
            //            User = context.Users.First(),
            //            ProductIdRef = 1,
            //            CreateDate = DateTime.Now.ToLongDateString(),
            //            Description = "Comment 1",
            //            Point = 5,
            //        },
            //        new Review
            //        {
            //            User = context.Users.First(),
            //            ProductIdRef = 1,
            //            CreateDate = DateTime.Now.ToLongDateString(),
            //            Description = "Comment 2",
            //            Point = 3,
            //        },
            //        new Review
            //        {
            //            User = context.Users.First(),
            //            ProductIdRef = 1,
            //            CreateDate = DateTime.Now.ToLongDateString(),
            //            Description = "Comment 3",
            //            Point = 2,
            //        }
            //        );

            //    context.Locations.AddOrUpdate(
            //        l => l.Name,
            //        new Location
            //        {
            //            Name = "Hà Nội",
            //            PostalCode = "0084",
            //            Shippable = 1,
            //        },
            //        new Location
            //        {
            //            Name = "Thanh Hóa",
            //            PostalCode = "0084",
            //            Shippable = 1,
            //        },
            //        new Location
            //        {
            //            Name = "Tp. Hồ Chí Minh",
            //            PostalCode = "0084",
            //            Shippable = 1,
            //        }
            //        );
            
            
        }
    }
}
