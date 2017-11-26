using System.Net;
using System.Net.Mail;
using Kowalsky.Models;
using Microsoft.Extensions.Options;

namespace Kowalsky.Services.Email
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly MailOptions _options;
        private readonly IEmailTemplateService _templateService;
        private readonly IErrorReporter _errorReporter;

        public EmailSenderService(IOptions<MailOptions> options, IEmailTemplateService templateService,
            IErrorReporter errorReporter)
        {
            _options = options.Value;
            _templateService = templateService;
            _errorReporter = errorReporter;
        }

        private MailMessage CreateMailMessage(MailAddress toAddress, string subject, string body)
        {
            return new MailMessage(new MailAddress(_options.From, "KrizsmaJogsi"), toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
        }

        private SmtpClient CreateSmtpClient()
        {
            return new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_options.From, _options.Password)
            };
        }

        public void SendEmails(ContactInfo contactInfo)
        {
            SendNotificationEmail(contactInfo);
        }

        public void SendNotificationEmail(ContactInfo contactInfo)
        {
            var toAddress = new MailAddress("krizsmajogsi@gmail.com");
            var template = _templateService.CreateNotificationEmailTemplate(contactInfo);

            SendEmail(toAddress, template.subject, template.body);
        }

        private void SendEmail(MailAddress toAddress, string subject, string body)
        {
            if (_options.Empty)
            {
                _errorReporter.CaptureAsync("Mail options are empty");
                return;
            }

            var smtp = CreateSmtpClient();

            using (var message = CreateMailMessage(toAddress, subject, body))
            {
                smtp.Send(message);
            }
        }

    }
}
