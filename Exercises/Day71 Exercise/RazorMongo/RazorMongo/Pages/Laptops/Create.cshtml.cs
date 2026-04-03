using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorMongo.Models;
using RazorMongo.Services;

namespace RazorMongo.Pages.Laptops
{
    public class CreateModel : PageModel
    {
        private readonly LaptopService _service;

        public CreateModel(LaptopService service)
        {
            _service = service;
        }

        [BindProperty]
        public Laptop Laptop { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _service.CreateAsync(Laptop);

            TempData["Success"] = "Laptop added successfully!";
            return RedirectToPage("Index");
        }
    }
}
