namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CartProduct
    {
        public int Id { get; set; }

        public int ProductIdRef { get; set; }

        public int? ShoppingCart_Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
