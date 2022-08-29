﻿using AnimalWeb.Models;
using AnimalWeb.Repositories;
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
        public IActionResult GetCategory(string category)
        {
            var data = _repository.GetAnimalsByCategory(category);
            return View(data);
        }
        public IActionResult Dogs()
        {
            return View();
        }
        public IActionResult Rabbits()
        {
            return View();
        }
        public IActionResult Cats()
        {
            return View();
        }
        public IActionResult Fish()
        {
            return View();
        }
        public IActionResult Iguwanas()
        {
            return View();
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
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

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
            return View();
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}