using AnimalWeb.Data;
using AnimalWeb.Models;
using AnimalWeb.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AnimalWeb.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Categories()
        {
            return View(_repository.GetCategories());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}