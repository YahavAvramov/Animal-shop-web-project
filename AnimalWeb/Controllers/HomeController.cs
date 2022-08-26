using AnimalWeb.Data;
using AnimalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AnimalWeb.Controllers
{
    public class HomeController : Controller
    {

        private Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Categories()
        {
            ViewBag.Categoties = _context.Categories.ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}