namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CreateDate { get; set; }

        public string ImageLink { get; set; }

        
        public virtual ICollection<Product> Products { get; set; }
    }
}
