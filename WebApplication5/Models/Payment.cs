using System.ComponentModel;

namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Người dùng")]
        [StringLength(128)]
        public string UserIdRef { get; set; }

        [Required]
        [DisplayName("Sản phẩm")]
        public int ProductIdRef { get; set; }

        [Required]
        [DisplayName("Đơn vận chuyển")]
        public int ShippingIdRef { get; set; }

        [Required]
        [DisplayName("Số lượng")]
        public string Amount { get; set; }
       
        [DisplayName("Ngày tạo")]
        public string CreateDate { get; set; }

        [Required]
        [DisplayName("ĐV tiền tệ")]
        public string Currency { get; set; }

        [Required]
        [DisplayName("Đã thanh toán ?")]
        public bool IsPaid { get; set; }

        [ForeignKey("UserIdRef")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ProductIdRef")]
        public virtual Product Product { get; set; }

        [ForeignKey("ShippingIdRef")]
        public virtual Shipping Shipping { get; set; }
    }
}
