using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinTrackPro.Models;

namespace FinTrackPro.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly static List<Asset> assets = new List<Asset>()
        {
            new Asset { Id = 1, Name = "Apple", Value = 15000 },
            new Asset { Id = 2, Name = "Microsoft", Value = 20000 },
            new Asset { Id = 3, Name = "Tesla", Value = 18000 }
        };

        // GET: PortfolioController
        public ActionResult Index()
        {
            ViewData["Total"] = assets.Sum(a => a.Value);
            return View(assets);
        }

        // Custom Route
        [Route("Asset/Info/{id:int}")]
        public ActionResult Details(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset == null)
            {
                TempData["Message"] = "Asset not found";
                return RedirectToAction(nameof(Index));
            }

            return View(asset);
        }

        // GET: PortfolioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortfolioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Asset asset)
        {
            try
            {
                asset.Id = assets.Max(a => a.Id) + 1;
                assets.Add(asset);

                TempData["Message"] = "Asset added successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PortfolioController/Edit/5
        public ActionResult Edit(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);
            return View(asset);
        }

        // POST: PortfolioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Asset updatedAsset)
        {
            try
            {
                var asset = assets.FirstOrDefault(a => a.Id == id);

                if (asset != null)
                {
                    asset.Name = updatedAsset.Name;
                    asset.Value = updatedAsset.Value;
                }

                TempData["Message"] = "Asset updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PortfolioController/Delete/5
        public ActionResult Delete(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset != null)
            {
                assets.Remove(asset);
                TempData["Message"] = "Asset deleted successfully";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
