using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Review
    {
        public int Id { get; set; }

        public int ProductIdRef { get; set; }

        public string Description { get; set; }

        public int Point { get; set; }

        public string CreateDate { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ProductIdRef")]
        public virtual Product Product { get; set; }

      
    }
}
