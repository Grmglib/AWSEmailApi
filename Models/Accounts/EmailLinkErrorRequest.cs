using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Accounts
{
    public class EmailLinkErrorRequest
    {
        [Required]
        public string Email { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
    }
