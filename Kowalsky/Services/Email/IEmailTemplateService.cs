using Kowalsky.Models;

namespace Kowalsky.Services.Email
{
    public interface IEmailTemplateService
    {
        (string subject, string body) CreateNotificationEmailTemplate(ContactInfo contactInfo);
    }
}
