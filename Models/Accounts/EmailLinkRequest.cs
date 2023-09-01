using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Accounts
{
    public class EmailLinkRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Link { get; set; }

        public string Title { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
    }
}