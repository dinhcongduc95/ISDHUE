using System.ComponentModel;

namespace WebApplication5.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Location
    {
        public Location()
        {
            
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Tên địa điểm")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Mã vùng")]
        public string PostalCode { get; set; }

        [Required]
        [DisplayName("Có thể chuyển phát")]
        public int Shippable { get; set; }
       
        [DisplayName("Ngày tạo")]
        public string CreateDate { get; set; }
     
    }
}
