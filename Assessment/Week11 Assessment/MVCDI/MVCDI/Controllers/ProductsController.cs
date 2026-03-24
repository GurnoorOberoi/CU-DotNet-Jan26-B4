using Microsoft.AspNetCore.Mvc;
using MVCDI.Services;

namespace MVCDI.Controllers
{
    public class ProductsController : Controller
    {
        private IPricingService _service { get; set; }
        public ProductsController(IPricingService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            //decimal basePrice = 5000;
            //string promoCode = "WINTER25";
            //decimal discountedPrice = _service.CalculatePrice(basePrice, promoCode);
            //ViewBag.basePrice = basePrice;
            //ViewBag.promoCode = promoCode;
            //ViewBag.Price = discountedPrice;
            ////decimal basePrice = 2000;
            //string promoCode1 = "FREESHIP";
            //decimal discountedPrice1 = _service.CalculatePrice(basePrice, promoCode);
            //ViewBag.basePrice = basePrice;
            //ViewBag.promoCode1 = promoCode1;
            //ViewBag.Total = discountedPrice1;
            return View();
        }
    }
}
