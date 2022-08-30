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

        public CategoriesController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult AllCategories()
        {

            return View(_repository.GetCategories());
        }
        public IActionResult GetCategory(string categoryName)
        {
            var data = _repository.GetAnimalsByCategory(categoryName);
            return View(data);
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
        public ActionResult Delete(int id, string category)
        {
            _repository.DeleteAnimal(id);
            return RedirectToAction("GetCategory", "Categories", new
            {

                id = category
            
            }) ;
        }


    }
}
