using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Store.BusinessLogic.Options;

namespace Store.BusinessLogic.Helpers
{
    public class EmailSender : IEmailSender
    {
        private IOptions<EmailOptions> _options;

        public EmailSender(IOptions<EmailOptions> options)
        {
            if (options == null || options.Value == null)
            {
                throw new ArgumentNullException("EmailOptions is null", "options");
            }
            _options = options;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient(_options.Value.Host, _options.Value.Port)
            {
                Credentials = new NetworkCredential(_options.Value.UserName, _options.Value.Password),
                EnableSsl = _options.Value.EnableSsl
            };

            var mailMessage = new MailMessage(_options.Value.UserName, email, subject, htmlMessage) { IsBodyHtml = true };
            return smtpClient.SendMailAsync(mailMessage);
        }
    }
}
