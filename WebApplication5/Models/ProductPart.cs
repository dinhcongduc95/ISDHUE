namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductPart
    {

        [Key]
        public int Id { get; set; }

        public int PartIdRef { get; set; }

        public int? ProductIdRef { get; set; }

        [ForeignKey("PartIdRef")]
        public virtual Part Part { get; set; }

        [ForeignKey("ProductIdRef")]
        public virtual Product Product { get; set; }
    }
}
