using Kowalsky.Controllers.Dtos;
using Kowalsky.Controllers.Sanitizers;
using Kowalsky.Services.Email;
using Kowalsky.Services.GoogleApi;
using Microsoft.AspNetCore.Mvc;

namespace Kowalsky.Controllers
{
    [Route("api/home")]
    public class ApiController : Controller
    {
        private readonly IHomeSanitizer _sanitizer;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IGoogleApiServices _googleApiServices;

        public ApiController(IHomeSanitizer sanitizer, IEmailSenderService emailSenderService, IGoogleApiServices googleApiServices)
        {
            _sanitizer = sanitizer;
            _emailSenderService = emailSenderService;
            _googleApiServices = googleApiServices;
        }

        [HttpPost]
        public IActionResult Contact([FromBody] ContactInfoDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var contactInfo = _sanitizer.SanitizeContactInfo(dto);

            _emailSenderService.SendEmails(contactInfo);
            _googleApiServices.SaveContactInfoToSpreadSheet(contactInfo);

            return Ok();
        }
    }
}
