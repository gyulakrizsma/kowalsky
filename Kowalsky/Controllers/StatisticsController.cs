using Microsoft.AspNetCore.Mvc;

namespace Kowalsky.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
