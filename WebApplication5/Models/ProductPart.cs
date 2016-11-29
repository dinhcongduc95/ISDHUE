namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductPart
    {
        public int Id { get; set; }

        public int PartIdRef { get; set; }

        public int? Product_Id { get; set; }

        public virtual Part Part { get; set; }

        public virtual Product Product { get; set; }
    }
}
