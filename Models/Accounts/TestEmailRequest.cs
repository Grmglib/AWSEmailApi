using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Accounts
{
    public class TestEmailRequest
    {
        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}