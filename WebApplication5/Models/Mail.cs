namespace WebApplication5.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Mail
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string UserIdRef { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MailContent { get; set; }

        public string DateCreated { get; set; }

        public int? IsSent { get; set; }

        public ApplicationUser User { get; set; }
    }
}
