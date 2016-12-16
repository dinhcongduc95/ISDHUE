namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CartProduct
    {
        [Key]
        public int Id { get; set; }

        public int ProductIdRef { get; set; }

        public int? ShoppingCartIdRef { get; set; }

        [ForeignKey("ProductIdRef")]
        public virtual Product Product { get; set; }

        [ForeignKey("ShoppingCartIdRef")]
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
