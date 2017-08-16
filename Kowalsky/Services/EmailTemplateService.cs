using System.Text;
using Kowalsky.Models;

namespace Kowalsky.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        public (string subject, string body) CreateConfirmationEmailTemplate(ContactInfo contactInfo)
        {
            const string subject = "Köszönjük a jelentkezését";

            var sb = new StringBuilder();
            sb.Append(
                "<p>Köszönjük, hogy megtisztelt a bizalmával. Rövid időn belül jelentkezni fogunk vagy az alábbi elérhetőségeken:<p>");

            sb.Append($"<p>Email: {contactInfo.Email}</p>");
            sb.Append($"<p>Telefon: {contactInfo.Phone}</p>");
            sb.Append("<p>Amennyiben a válaszunkra nem tud várni, kérem hívja az 0630 970 6890-es számot. </p>");
            sb.Append("<p>Üdvözlettel,<br />Krizsma Gábor</p>");

            return (subject, sb.ToString());
        }

        public (string subject, string body) CreateNotificationEmailTemplate(ContactInfo contactInfo)
        {
            var subject = $"{contactInfo.Name} jelentkezett a weboldalon keresztül";

            var sb = new StringBuilder();
            sb.Append("<p>Az alábbi személy jelentkezett a weboldalon keresztül<p>");
            sb.Append($"<p>Név: {contactInfo.Name}</p>");
            sb.Append($"<p>Telefon: {contactInfo.Phone}</p>");

            if (!string.IsNullOrWhiteSpace(contactInfo.Comment))
            {
                sb.Append($"<p>Megjegyzés: {contactInfo.Comment}</p>");
            }

            return (subject, sb.ToString());
        }
    }
}
