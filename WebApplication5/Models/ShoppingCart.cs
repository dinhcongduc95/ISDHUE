using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ShoppingCart
    {        
        public ShoppingCart()
        {
           
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        [DisplayName("Người dùng")]
        public string UserIdRef { get; set; }

        [Required]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [DisplayName("Ngày tạo")]
        public string CreateDate { get; set; }

        [ForeignKey("UserIdRef")]
        public virtual ApplicationUser User { get; set; }
               
    }
}
