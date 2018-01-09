using System.Threading.Tasks;
using Kowalsky.Controllers.Dtos;
using Kowalsky.Controllers.Sanitizers;
using Kowalsky.Services.GoogleApi;
using Microsoft.AspNetCore.Mvc;

namespace Kowalsky.Controllers
{
    [Route("api/home")]
    public class ApiController : Controller
    {
        private readonly IHomeSanitizer _sanitizer;
        private readonly IGoogleApiServices _googleApiServices;

        public ApiController(IHomeSanitizer sanitizer, IGoogleApiServices googleApiServices)
        {
            _sanitizer = sanitizer;
            _googleApiServices = googleApiServices;
        }

        [HttpPost]
        public async Task<IActionResult> Contact([FromBody] ContactInfoDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var contactInfo = _sanitizer.SanitizeContactInfo(dto);

            await _googleApiServices.SaveContactInfoToSpreadSheetAsync(contactInfo);

            return Ok();
        }
    }
}
