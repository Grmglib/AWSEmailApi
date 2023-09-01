using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Accounts
{
    public class CustomEmailRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject {get; set;}
        [Required]
        public string Message {get; set;}

        public String FilePath { get; set; }

        public string Date { get;set;}

        public string Status { get; set; }
    }
}