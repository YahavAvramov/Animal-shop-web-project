using AnimalWeb.Data;
using AnimalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AnimalWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Context _context;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public HomeController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categoris()
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