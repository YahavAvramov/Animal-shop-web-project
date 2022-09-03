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
        public static bool _isAdmin;
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
        public IActionResult CreateCategory(string Name, string CategoryPicture)
        {
            _repository.CreateCategory(Name, CategoryPicture);

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
            if (_isAdmin)
            {
                _isAdmin = false;
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult CreateAnimal()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveAnimalToDb(string name, int age, int price, string description, string pictureName, string categoryName)
        {
            _repository.CreateAnimal(name, age, price, description, pictureName, categoryName);
            return RedirectToAction("GetCategory", "Categories", new { categoryName = categoryName });
        }
        public IActionResult Edit(int id)
        {
            return View(_repository.GetAnimalById(id));
        }
        [HttpPost]
        public IActionResult SaveAnimalChanges(string name, int age, int price, string description, string pictureName, int id)
        {
            _repository.UpdateAnimal(name, age, price, description, pictureName, id);
            string categoryName = _repository.GetCategoryById(id);

            return RedirectToAction("GetCategory", "Categories", new { categoryName = categoryName });
        }

        public IActionResult Delete(int id)
        {
            string categoryName = _repository.GetCategoryById(id);
            _repository.DeleteAnimal(id);
            return RedirectToAction("GetCategory", "Categories", new { categoryName = categoryName });
        }
        public IActionResult GetCommentsForAnimal(int Id)
        {

            return View(_repository.GetCommentsById(Id));
        }



    }

}

