namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string UserIdRef { get; set; }

        public int ProductIdRef { get; set; }

        public int ShippingIdRef { get; set; }

        public string Amount { get; set; }

        public string Currency { get; set; }

        public int? IsPaid { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Product Product { get; set; }

        public virtual Shipping Shipping { get; set; }
    }
}
