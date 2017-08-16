using Kowalsky.Controllers.Dtos;
using Kowalsky.Models;

namespace Kowalsky.Controllers.Sanitizers
{
    public interface IHomeSanitizer
    {
        ContactInfo SanitizeContactInfo(ContactInfoDto dto);
    }
}
