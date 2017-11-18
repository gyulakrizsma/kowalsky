using Kowalsky.Controllers.Dtos;
using Kowalsky.Controllers.Sanitizers;
using Kowalsky.Services.Email;
using Microsoft.AspNetCore.Mvc;

namespace Kowalsky.Controllers
{
    [Route("api/home")]
    public class ApiController : Controller
    {
        private readonly IHomeSanitizer _sanitizer;
        private readonly IEmailSenderService _emailSenderService;

        public ApiController(IHomeSanitizer sanitizer, IEmailSenderService emailSenderService)
        {
            _sanitizer = sanitizer;
            _emailSenderService = emailSenderService;
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

            return Ok();
        }
    }
}
