using Microsoft.AspNetCore.Mvc;
using TheVagabondTravelFrontend.Models;
using TheVagabondTravelFrontend.Services;

namespace TheVagabondTravelFrontend.Controllers
{
    public class TravelController : Controller
    {
        private readonly IDestinationService _service;
        public TravelController(IDestinationService service)
        {
            _service = service;
        }
        public async Task<IActionResult>Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Destination destination)
        {
            await _service.CreateAsync(destination);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var destination = await _service.GetByIdAsync(id);
            return View(destination);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Destination destination)
        {
            await _service.UpdateAsync(destination);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
