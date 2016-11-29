using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication5.ChatHub.Models;

namespace WebApplication5.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<CartProduct> CartProducts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Mail> Mails { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<ProductPart> ProductParts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Shipping> Shippings { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }       
       

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}