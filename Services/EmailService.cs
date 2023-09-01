using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html, string from = null, string filePath = null, string link = null);
    }

    public class EmailService : IEmailService
    {
        private readonly AppSettings _appSettings;

        public EmailService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public void Send(string to, string subject, string html, string from = null, string filePath = null, string link = null)
        {
            // create message
            var multiPart = new Multipart("mixed");
            if (filePath != null)
            {
                var builder = new BodyBuilder();
                builder.Attachments.Add(filePath);
                multiPart.Add(builder.ToMessageBody());
            }
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _appSettings.EmailFrom));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            multiPart.Add(new TextPart(TextFormat.Html) { Text = html });
            email.Body = multiPart;
            // send email
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.CheckCertificateRevocation = false; //Fixes SSL error
            smtp.Connect(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}