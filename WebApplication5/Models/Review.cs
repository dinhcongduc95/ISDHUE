using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Review
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Sản phẩm")]
        public int ProductIdRef { get; set; }

        [Required]
        [DisplayName("Người dùng")]
        public string UserIdRef { get; set; }

        [Required]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Điểm số")]
        public int Point { get; set; }
       
        [DisplayName("Ngày tạo")]
        public string CreateDate { get; set; }

        [ForeignKey("UserIdRef")]
        public ApplicationUser User { get; set; }

        [ForeignKey("ProductIdRef")]
        public Product Product { get; set; }

      
    }
}
