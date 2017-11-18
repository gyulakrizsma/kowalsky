using Kowalsky.Models;

namespace Kowalsky.Services.Email
{
    public interface IEmailSenderService
    {
        void SendEmails(ContactInfo contactInfo);

        void SendNotificationEmail(ContactInfo contactInfo);
    }
}
