using System.ComponentModel;

namespace WebApplication5.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Mail
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Người dùng")]
        [StringLength(128)]
        public string UserIdRef { get; set; }

        [Required]
        [DisplayName("Chủ đề")]
        public string Title { get; set; }
        
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Nội dung")]
        public string MailContent { get; set; }
        
        [DisplayName("Chủ đề")]
        public string CreateDate{ get; set; }

        [Required]
        [DisplayName("Đã gửi ?")]
        public bool IsSent { get; set; }

        public ApplicationUser User { get; set; }
    }
}
