using Kowalsky.Models;

namespace Kowalsky.Services
{
    public interface IEmailTemplateService
    {
        (string subject, string body) CreateNotificationEmailTemplate(ContactInfo contactInfo);
    }
}
