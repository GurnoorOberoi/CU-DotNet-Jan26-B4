using Microsoft.AspNetCore.Mvc;

namespace FinTrackPro.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Summary()
        {
            ViewBag.MarketStatus = "Open";
            ViewData["TopGainer"] = "NVIDIA";

            return View();
        }

        public IActionResult Analyze(string ticker, int? days)
        {
            ViewBag.Ticker = ticker;
            ViewBag.Days = days;

            return View();
        }
    }
}
