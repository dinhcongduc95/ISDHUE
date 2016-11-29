namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Location
    {
        public Location()
        {
            Shippings = new HashSet<Shipping>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string PostalCode { get; set; }

        public int Shippable { get; set; }
       
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
