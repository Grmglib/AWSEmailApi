using AutoMapper;
using Microsoft.Extensions.Options;
using WebApi.Helpers;
using WebApi.Models.Accounts;

namespace WebApi.Services
{
    //Interface
    public interface IAccountService
    {
        void EmailLink(EmailLinkRequest model);
        void EmailLinkError(EmailLinkErrorRequest model);
        void CustomEmail(CustomEmailRequest model);
        void Test(TestEmailRequest model);
    }

    public class AccountService : IAccountService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public AccountService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
        }
        public void EmailLink(EmailLinkRequest model) 
        {
            sendEmailLink(model.Email, model.Message, model.Subject, model.Link);
        }
        public void EmailLinkError(EmailLinkErrorRequest model) 
        {
            sendEmailLinkError(model.Email, model.Message,model.Subject);
        }
        public void CustomEmail(CustomEmailRequest model)
        {
            sendCustomEmail(model.Email, model.Message, model.Subject, model.FilePath,model.Date, model.Status);
        }

        public void Test(TestEmailRequest model)
        {
            sendTestEmail(model.Email);
        }

        //Metods
        private void sendEmailLink(string email, string message, string subject, string link)
        {
            _emailService.Send
                (
                to: email,
                subject: $"{subject}",
                html: $"{message}",
                link: $"{link}"
                );
        }
        private void sendEmailLinkError(string email, string message, string subject)
        {
            _emailService.Send
                (
                to: email,
                subject: $"{subject}",
                html: $"{message}"
                );
        }
        private void sendCustomEmail(string email, string message, string subject, string filePath, string date, string status)
        {
            _emailService.Send
                (
                to: email,
                subject: $"{subject}",
                html: $"{message}",
                filePath: filePath
                
                );
        }

        private void sendTestEmail(string email)
        {
            string message;
            message = "this is a test";

            _emailService.Send(
                to: email,
                subject: "Test",
                html: $@"<h4>Test</h4>
                         <p>checking functionality.</p>{message}"
            );
        }
    }
}