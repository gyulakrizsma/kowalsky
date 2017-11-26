using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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

        public async Task SendEmailAsync(ContactInfo contactInfo)
        {
            await SendNotificationEmailAsync(contactInfo);
        }

        private async Task SendNotificationEmailAsync(ContactInfo contactInfo)
        {
            var toAddress = new MailAddress("krizsmajogsi@gmail.com");
            var template = _templateService.CreateNotificationEmailTemplate(contactInfo);

            await SendEmailAsync(toAddress, template.subject, template.body);
        }

        private async Task SendEmailAsync(MailAddress toAddress, string subject, string body)
        {
            if (_options.Empty)
            {
                await _errorReporter.CaptureAsync("Mail options are empty");
                return;
            }

            var smtp = CreateSmtpClient();

            using (var message = CreateMailMessage(toAddress, subject, body))
            {
                await smtp.SendMailAsync(message);
            }
        }

    }
}
