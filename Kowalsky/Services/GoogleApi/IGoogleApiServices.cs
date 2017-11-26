using System.Threading.Tasks;
using Kowalsky.Models;

namespace Kowalsky.Services.GoogleApi
{
    public interface IGoogleApiServices
    {
        Task SaveContactInfoToSpreadSheetAsync(ContactInfo contact);
    }
}
