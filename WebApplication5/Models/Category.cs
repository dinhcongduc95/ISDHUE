using System.ComponentModel;

namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        
        public Category()
        {           
        }

        [Key]
        public int Id { get; set; }

        [DisplayName("Mã hàng")]
        [Required]
        public string Code { get; set; }

        [DisplayName("Tên")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [DisplayName("Ngày tạo")]
        public string CreateDate { get; set; }

        [DisplayName("Hình ảnh")]
        [Required]
        public string ImageLink { get; set; }
                
    }
}
