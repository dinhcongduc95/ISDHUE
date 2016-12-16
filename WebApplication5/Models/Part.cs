using System.ComponentModel;

namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Part
    {
        
        public Part()
        {
            
        }

        [Key]
        public int Id { get; set; }

        [DisplayName("Tên")]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Hình ảnh")]
        [Required]
        public string ImageLink { get; set; }

        [DisplayName("Xuất sứ")]
        [Required]
        public string Origin { get; set; }

        [DisplayName("Nhà sản xuất")]
        [Required]
        public string Manufacturer { get; set; }

        [DisplayName("Ngày tạo")]        
        public string CreateDate { get; set; }

        [DisplayName("Tài liệu")]
        [Required]
        public int DocumentIdRef { get; set; }

        [ForeignKey("DocumentIdRef")]
        public virtual Document Document { get; set; }
       
    }
}
