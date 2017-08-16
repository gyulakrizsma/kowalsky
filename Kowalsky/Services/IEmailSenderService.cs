using Kowalsky.Models;

namespace Kowalsky.Services
{
    public interface IEmailSenderService
    {
        void SendEmails(ContactInfo contactInfo);

        void SendConfirmationEmail(ContactInfo contactInfo);

        void SendNotificationEmail(ContactInfo contactInfo);
    }
}
