namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        
        public Product()
        {
            CartProducts = new HashSet<CartProduct>();
            Payments = new HashSet<Payment>();
            ProductParts = new HashSet<ProductPart>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public string Origin { get; set; }

        public string CreateDate { get; set; }

        public string ImageLink{ get; set; }

        
        public int CategoryIdRef { get; set; }

        public int DocumentIdRef { get; set; }


        [ForeignKey("CategoryIdRef")]
        public virtual Category Category { get; set; }

        [ForeignKey("DocumentIdRef")]
        public virtual Document Document { get; set; }

        
        public virtual ICollection<Payment> Payments { get; set; }

       
        public virtual ICollection<ProductPart> ProductParts { get; set; }

        
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
