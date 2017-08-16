using System;
using Kowalsky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kowalsky.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var schedules = new[]
            {
                new Schedule(new DateTime(2017, 4, 18), new DateTime(2017, 4, 19), new DateTime(2017, 4, 20), new DateTime(2017, 4, 24), new DateTime(2017, 4, 25), new DateTime(2017, 4, 26), new DateTime(2017, 4, 27)),
                new Schedule(new DateTime(2017, 5, 15), new DateTime(2017, 5, 17), new DateTime(2017, 5, 18), new DateTime(2017, 5, 22), new DateTime(2017, 5, 24), new DateTime(2017, 5, 25), new DateTime(2017, 5, 29)),
                new Schedule(new DateTime(2017, 6, 12), new DateTime(2017, 6, 14), new DateTime(2017, 6, 15), new DateTime(2017, 6, 19), new DateTime(2017, 6, 21), new DateTime(2017, 6, 22), new DateTime(2017, 6, 26)),
                new Schedule(new DateTime(2017, 7, 17), new DateTime(2017, 7, 19), new DateTime(2017, 7, 20), new DateTime(2017, 7, 24), new DateTime(2017, 7, 26), new DateTime(2017, 7, 27), new DateTime(2017, 7, 31)),
            };

            var prices = new[]
            {
                new Price(7000, "Orvosi alkamlassági vizsgálat", ""),
                new Price(7000, "Egészségügyi tanfolyam", "Test"),
                new Price(5500, "Egészségügyi vizsgadíj", ""),
                new Price(4600, "Elméleti vizsgadíj (kresz teszt)", "Test"),
                new Price(1100, "Forgalmi vizsgadíj", "")
            };

            var comments = new[]
            {
                new Comment("Rendkívül elégedett voltam a szolgáltatásokkal.", "Kovács Dezső", "Tervező mérnök"),
                new Comment("A krizsmajogsi a legjobb autósiskola a fővárosban. Mindenkinek ajánlom. Gábor egy sokat tudó jól képzett szakember. Örülök, hogy nála tanulhattam meg vezetni", "Kiss Kinga", "Fogászati asszisztens"),
                new Comment("A E-learning szolgáltatás segítségével sokkal könnyebben tudtam megtanulni a tananyagot. A gyakorlati vezetés pedig magas szinten történt, egy igen jól felszerelt autóval.", "Kedves Ferenc", "Sofőr")
            };

            var model = new HomeOverviewViewModel(99000, schedules, prices, comments);

            return View(model);
        }
    }
}
