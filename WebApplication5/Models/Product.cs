using System.ComponentModel;

namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        
        public Product()
        {            
        }

        public int Id { get; set; }
        
        [Required]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }

        [DisplayName("Mô tả sản phẩm")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Giá")]
        public decimal? Price { get; set; }

        [DisplayName("Xuất xứ")]
        public string Origin { get; set; }

        [DisplayName("Ngày tạo")]
        public string CreateDate { get; set; }

        [DisplayName("Hình ảnh")]
        public string ImageLink{ get; set; }

        [Required]
        [DisplayName("Danh mục")]
        public int CategoryIdRef { get; set; }

        // khóa phụ foreignkey lấy từ bảng Document sang
        [Required]
        [DisplayName("Tài liệu hướng dẫn")]
        public int DocumentIdRef { get; set; }

       
        // khóa phụ foreignkey lấy từ bảng Category sang
        [DisplayName("Danh mục")]
        [ForeignKey("CategoryIdRef")]
        public virtual Category Category { get; set; }

        // khóa phụ foreignkey lấy từ bảng Document sang
        [DisplayName("Tài liệu hướng dẫn")]
        [ForeignKey("DocumentIdRef")]
        public virtual Document Document { get; set; }
                
    }
}
