namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Part
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Part()
        {
            ProductParts = new HashSet<ProductPart>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Origin { get; set; }

        public string Manufacturer { get; set; }

        public string CreateDate { get; set; }

        public int DocumentIdRef { get; set; }

        public virtual Document Document { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPart> ProductParts { get; set; }
    }
}
