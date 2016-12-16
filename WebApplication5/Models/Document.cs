using System.ComponentModel;

namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Document
    {
        
        public Document()
        {           
        }

        [Key]
        public int Id { get; set; }

        [DisplayName("Tên tài liệu")]
        [Required]
        public string Title { get; set; }

        [DisplayName("Nội dung")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Ngày tạo")]        
        public string CreateDate { get; set; }              
    }
}
