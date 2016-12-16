using System.ComponentModel;

namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shipping
    {        
        public Shipping()
        {            
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Địa chỉ")]
        public int LocationIdRef { get; set; }

        [Required]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Cách thanh toán")]
        public string PaymentType { get; set; }

        [Required]
        [DisplayName("Hạn cuối")]
        public string DeadLine { get; set; }

        [Required]
        [DisplayName("Điện thoại")]
        public string PhoneNo { get; set; }

        [DisplayName("Ngày tạo")]
        public string CreateDate { get; set; }

        [ForeignKey("LocationIdRef")]
        public Location Location { get; set; }
        
    }
}
