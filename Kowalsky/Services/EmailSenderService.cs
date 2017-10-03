﻿using System.Net;
using System.Net.Mail;
using Kowalsky.Models;

namespace Kowalsky.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IEmailTemplateService _templateService;
        private readonly string _from;
        private readonly string _password;

        public EmailSenderService(IEmailTemplateService templateService, string from, string password)
        {
            _from = from;
            _templateService = templateService;
            _password = password;
        }

        private MailMessage CreateMailMessage(MailAddress toAddress, string subject, string body)
        {
            var message = new MailMessage(new MailAddress(_from, "KrizsmaJogsi"), toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            message.CC.Add(new MailAddress("krizsmag@freemail.hu"));

            return message;
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
                Credentials = new NetworkCredential(_from, _password)
            };
        }

        public void SendEmails(ContactInfo contactInfo)
        {
            SendConfirmationEmail(contactInfo);
            SendNotificationEmail(contactInfo);
        }

        public void SendConfirmationEmail(ContactInfo contactInfo)
        {
            var toAddress = new MailAddress(contactInfo.Email, contactInfo.Name);
            var template = _templateService.CreateConfirmationEmailTemplate(contactInfo);

            SendEmail(toAddress, template.subject, template.body);
        }

        public void SendNotificationEmail(ContactInfo contactInfo)
        {
            var toAddress = new MailAddress("gyula.krizsma@softfactors.com", contactInfo.Name);
            var template = _templateService.CreateNotificationEmailTemplate(contactInfo);

            SendEmail(toAddress, template.subject, template.body);
        }

        private void SendEmail(MailAddress toAddress, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(_from) || string.IsNullOrWhiteSpace(_password))
            {
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
