using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorMongo.Models;
using RazorMongo.Services;

namespace RazorMongo.Pages.Laptops
{
    public class IndexModel : PageModel
    {
        private readonly LaptopService _service;

        public IndexModel(LaptopService service)
        {
            _service = service;
        }

        public List<Laptop> Laptops { get; set; }

        public async Task OnGetAsync()
        {
            Laptops = await _service.GetAsync();
        }
    }
}
