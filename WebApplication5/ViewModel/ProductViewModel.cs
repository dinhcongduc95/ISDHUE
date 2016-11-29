using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public string Origin { get; set; }

        public string CreateDate { get; set; }

        public string ImageLink { get; set; }


        public int CategoryIdRef { get; set; }

        public int DocumentIdRef { get; set; }


        
        public virtual Category Category { get; set; }

        
        public virtual Document Document { get; set; }


        public virtual ICollection<Payment> Payments { get; set; }


        public virtual ICollection<ProductPart> ProductParts { get; set; }


        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}