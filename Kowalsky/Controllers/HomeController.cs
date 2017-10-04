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
                new Schedule(new DateTime(2017, 9, 18), new DateTime(2017, 9, 20), new DateTime(2017, 9, 21), new DateTime(2017, 9, 25), new DateTime(2017, 9, 27), new DateTime(2017, 9, 28), new DateTime(2017, 10, 02)),
                new Schedule(new DateTime(2017, 10, 16), new DateTime(2017, 10, 18), new DateTime(2017, 10, 19), new DateTime(2017, 10, 24), new DateTime(2017, 10, 25), new DateTime(2017, 10, 26), new DateTime(2017, 10, 30)),
                new Schedule(new DateTime(2017, 11, 13), new DateTime(2017, 11, 15), new DateTime(2017, 11, 16), new DateTime(2017, 11, 20), new DateTime(2017, 11, 22), new DateTime(2017, 11, 23), new DateTime(2017, 11, 27)),
            };

            var priceModel = new PriceModel(99000, new[]
            {
                new Price(7000, "Orvosi alkalmassági vizsgálat", ""),
                new Price(7000, "Egészségügyi tanfolyam", ""),
                new Price(5500, "Egészségügyi vizsgadíj", ""),
                new Price(4600, "Elméleti vizsgadíj (kresz teszt)", ""),
                new Price(11000, "Forgalmi vizsgadíj", "")
            });

            var comments = new[]
            {
                new Comment("Szuper volt az elméleti oktatás, amit Krizsma Gábor tartott, külön köszönet az oktatómnak, Császár Viktornak, kismamakánt különösen értékeltem a türelmes és segítőkész hozzáállását.", "Keszthelyiné Simon Viktória", ""),
                new Comment("Legjobb suli, érdekesek az órái, vezetői oktatása nyugis. Köszönjük K. Gábor", "Trudics Kriszta", "")
            };

            var model = new HomeOverviewViewModel(99000, schedules, priceModel, comments);

            return View(model);
        }
    }
}
