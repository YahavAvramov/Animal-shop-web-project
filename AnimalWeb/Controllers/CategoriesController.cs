using AnimalWeb.Models;
using AnimalWeb.Repositories;
using AnimalWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private IRepository _repository;
        protected static bool _isAdmin;
        public CategoriesController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult SignAdmin(bool isAdmin)
        {
            _isAdmin = isAdmin;
            return RedirectToAction("AllCategories");
        }
        public IActionResult AllCategories()
        {
            ViewBag.isAdmin = _isAdmin;
            return View(_repository.GetCategories());
        }
        public IActionResult MakeNewCategoryForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory( string Name, int ID, string CategoryPicture)
        {
            _repository.CreateCategory(Name, ID, CategoryPicture);

            return RedirectToAction("AllCategories");
        }


        public IActionResult GetCategory(string categoryName)
        {

            ViewBag.isAdmin = _isAdmin;
            var data = _repository.GetAnimalsByCategory(categoryName);
            return View(data);
        }
        public IActionResult LogOut()
        {
            if (_isAdmin) {
                _isAdmin = false;
              
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5



        public ActionResult Delete(int id)
        {
            string categoryName = _repository.GetCategoryById(id);
            _repository.DeleteAnimal(id);
            return RedirectToAction("GetCategory", "Categories", new { categoryName = categoryName });
        }


    }
}
