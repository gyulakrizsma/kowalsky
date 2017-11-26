using Kowalsky.Models;

namespace Kowalsky.Services.GoogleApi
{
    public interface IGoogleApiServices
    {
        void SaveContactInfoToSpreadSheet(ContactInfo contact);
    }
}
