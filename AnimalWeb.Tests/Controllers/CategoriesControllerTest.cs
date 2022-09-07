using AnimalWeb.Controllers;
using AnimalWeb.Models;
using AnimalWeb.Tests.FakeRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalWeb.Tests.Controllers
{
    [TestClass]
    public class CategoriesControllerTest
    {
        [TestMethod]
        public void ShowCategories()
        {
            var categoriesRepository = new FakeMyRepository();
            var categoriesController = new CategoriesController(categoriesRepository);

            var result = categoriesController.AllCategories() as ViewResult;

            Assert.AreEqual(typeof(List<Categories>), result!.Model!.GetType());
        }

        [TestMethod]
        public void ShowAnimals()
        {
            var animalsRepository = new FakeMyRepository();
            var categoriesController = new CategoriesController(animalsRepository);

            var result = categoriesController.GetCategory("Dogs") as ViewResult;

            Assert.AreEqual(typeof(List<Animals>), result!.Model!.GetType());
        }
        [TestMethod]
        public void AnimalPerformance_Pin()
        {
            DateTime dt = DateTime.Now;
            var animalsRepository = new FakeMyRepository();
            var categoriesController = new CategoriesController(animalsRepository);

            var result = categoriesController.GetCommentsForAnimal(1, "path");
            var timeSpend = DateTime.Now - dt;
            Assert.IsTrue(timeSpend < TimeSpan.FromSeconds(0.5));
        }


    }
}
