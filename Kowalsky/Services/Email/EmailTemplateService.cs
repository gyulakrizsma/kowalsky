using System.Text;
using Kowalsky.Models;

namespace Kowalsky.Services.Email
{
    public class EmailTemplateService : IEmailTemplateService
    {
        public (string subject, string body) CreateNotificationEmailTemplate(ContactInfo contactInfo)
        {
            var subject = $"{contactInfo.Name} jelentkezett a weboldalon keresztül";

            var sb = new StringBuilder();
            sb.Append("<p>Az alábbi személy jelentkezett a weboldalon keresztül<p>");
            sb.Append($"<p>Név: {contactInfo.Name}</p>");
            sb.Append($"<p>Telefon: {contactInfo.Phone}</p>");
            sb.Append($"<p>E-mail cím: {contactInfo.Email}</p>");

            if (!string.IsNullOrWhiteSpace(contactInfo.Comment))
            {
                sb.Append($"<p>Megjegyzés: {contactInfo.Comment}</p>");
            }

            return (subject, sb.ToString());
        }
    }
}
