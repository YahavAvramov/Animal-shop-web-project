using AnimalWeb.Models;
using AnimalWeb.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;


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

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AdminConnectionForm(bool alart = false)
        {
            ViewBag.alart = alart;
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string returnurl = null)
        {

            return RedirectToAction("SignAdmin", "Categories", new { isAdmin = true });
        }
        public IActionResult ChangingForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckAdminDetails(string Email, string Password, string ID)
        {
           
            bool isUser = _userRepository.CheckUser(Email , Password);
            if (!isUser)
            {
                return RedirectToAction("AdminConnectionForm", "Admin" , new {alart = true});
            }
            return RedirectToAction("SignAdmin", "Categories", new { isAdmin = true });
        }

      

    }
}
