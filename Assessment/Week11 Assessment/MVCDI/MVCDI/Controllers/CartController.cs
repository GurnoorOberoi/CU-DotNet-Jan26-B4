using Microsoft.AspNetCore.Mvc;
using MVCDI.Services;

namespace MVCDI.Controllers
{
    public class CartController : Controller
    {
        private IPricingService _service { get; set; }
        public CartController(IPricingService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult AddToCart(decimal basePrice, string promoCode)
        {
            return RedirectToAction("Index", new { basePrice, promoCode });
        }
        public IActionResult Index(decimal basePrice, string promoCode)
        {
            //decimal basePrice = 2000;
            //string promoCode = "FREESHIP";
            decimal discountedPrice = _service.CalculatePrice(basePrice, promoCode);
            ViewBag.basePrice = basePrice;
            ViewBag.promoCode = promoCode;
            ViewBag.Total = discountedPrice;
            return View();
        }
    }
}
