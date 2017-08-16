using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kowalsky.Controllers
{
    [Route("api/home")]
    public class ApiController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IActionResult Contact([FromBody] ContactInfoDto item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        public class ContactInfoDto
        {
            public string Name { get; set; }

            public string Email { get; set; }

            public string Phone { get; set; }

            public string Comment { get; set; }
        }
    }
}
