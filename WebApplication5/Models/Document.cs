namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Document
    {
        
        public Document()
        {
            Parts = new HashSet<Part>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string DateCreated { get; set; }

        
        public virtual ICollection<Part> Parts { get; set; }

        
        public virtual ICollection<Product> Products { get; set; }
    }
}
