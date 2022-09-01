using AnimalWeb.Models;
using AnimalWeb.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWeb.Controllers
{
    public class AdminController : Controller
    {
        private IUserRepository _userRepository;
        public AdminController(IUserRepository repository)
        {
            _userRepository = repository;
        }
        public ActionResult Index()
        {
            bool isUser = _userRepository.CheckUser("yahav99999@gmail.com", "123456");
            return Content(isUser.ToString());
        }
        public IActionResult AdminConnectionForm()
        {
            return View();
        }
        public IActionResult ChangingForm()
        {
            return View();
        }
        public IActionResult checkAdminDetails(string email , string password)
        {
            bool isUser = _userRepository.CheckUser(email , password);
            if (!isUser)
            {
                return RedirectToAction("AdminConnectionForm", "Admin");
            }
            return RedirectToAction("AllCategories", "Categories", new { isAdmin = isUser });
        }

    }
}
