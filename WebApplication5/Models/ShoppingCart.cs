namespace WebApplication5.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ShoppingCart
    {        
        public ShoppingCart()
        {
            CartProducts = new HashSet<CartProduct>();
        }

        public int Id { get; set; }

        [StringLength(128)]
        public string UserIdRef { get; set; }

        public string Name { get; set; }

        public string CreateDate { get; set; }

        public virtual ApplicationUser User { get; set; }
       
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
