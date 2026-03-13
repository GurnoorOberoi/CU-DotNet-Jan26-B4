using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCModels.Models;

namespace MVCModels.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Rahul Sharma", Position = "Software Engineer", Salary = 65000 },
                new Employee { Id = 2, Name = "Priya Mehta", Position = "UI/UX Designer", Salary = 60000 },
                new Employee { Id = 3, Name = "Arjun Singh", Position = "Backend Developer", Salary = 70000 },
                new Employee { Id = 4, Name = "Neha Kapoor", Position = "Project Manager", Salary = 90000 }
            };
            ViewBag.Announcement = "Team meeting today at 4 PM in Conference Room.";

            ViewData["DepartmentName"] = "Software Development Department";
            ViewData["ServerStatus"] = true; // true = Active

            return View(employees);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
