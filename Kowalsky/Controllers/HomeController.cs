﻿using Kowalsky.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kowalsky.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var priceModel = new PriceModel(111000,
                new[]
                {
                    new Price(30000, "Tantermi képzés", "A tananyagot egy szakoktató előadásai során sajátíthatod el, mely előadásokon kötelező megjelenned. Tantermi képzést legalább 5 fő egyidejű jelentkezése esetén indítunk."),
                    new Price(36000, "E-Learning", "Az elméleti vizsgához szükséges tananyaghoz, a bejelentkezéstől számított 24 órán belül, iskolánk elektronikus hozzáférést biztosít számodra, melyet otthon is megtanulhatsz, idődet szabadon beosztva.")
                },
                new[]
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

            var model = new HomeOverviewViewModel(99000, priceModel, comments);

            return View(model);
        }
    }
}
