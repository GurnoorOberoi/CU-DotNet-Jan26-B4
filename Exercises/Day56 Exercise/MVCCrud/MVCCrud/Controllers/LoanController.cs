using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCrud.Models;

namespace MVCCrud.Controllers
{
    public class LoanController : Controller
    {
        private static List<Loan> loans = new List<Loan>();

        // GET: LoanController
        public ActionResult Index()
        {
            return View(loans);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.Id = loans.Count + 1;
                loans.Add(loan);

                return RedirectToAction("Index");
            }

            return View(loan);
        }

        // EDIT - GET
        public ActionResult Edit(int id)
        {
            var loan = loans.FirstOrDefault(x => x.Id == id);

            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Loan loan)
        {
            if (ModelState.IsValid)
            {
                var existingLoan = loans.FirstOrDefault(x => x.Id == loan.Id);

                if (existingLoan != null)
                {
                    existingLoan.BorrowerName = loan.BorrowerName;
                    existingLoan.LenderName = loan.LenderName;
                    existingLoan.Amount = loan.Amount;
                    existingLoan.IsSettled = loan.IsSettled;
                }

                return RedirectToAction("Index");
            }

            return View(loan);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var loan = loans.FirstOrDefault(x => x.Id == id);

            if (loan == null)
            {
                return NotFound();
            }

            return View(loan); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Loan loan)
        {
            var existingLoan = loans.FirstOrDefault(x => x.Id == id);

            if (existingLoan != null)
            {
                loans.Remove(existingLoan);
            }

            return RedirectToAction("Index");
        }
    }
}
