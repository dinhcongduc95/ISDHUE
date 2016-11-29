using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication5.Models;

namespace WebApplication5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            
            var context = new ApplicationDbContext();

            if (!context.Roles.Any(role => role.Name == "SuperAdmin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole("SuperAdmin"));
            }
            if (!context.Roles.Any(role => role.Name == "Customer"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole("Customer"));
            }
            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole("Admin"));
            }

            if (!context.Users.Any(user => user.UserName == "admin@admin.com"))
            {
                var UserManagerFactory = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };
                var result = UserManagerFactory.Create(user, "admin123");
                UserManagerFactory.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(user => user.UserName == "customer@customer.com"))
            {
                var UserManagerFactory = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = new ApplicationUser { UserName = "customer@customer.com", Email = "customer@customer.com" };
                var result = UserManagerFactory.Create(user, "customer123");
                UserManagerFactory.AddToRole(user.Id, "Customer");
            }
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
