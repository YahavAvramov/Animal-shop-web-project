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
        public IActionResult AdminSignUpForm(bool error = false)
        {
            ViewBag.error = error;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AdminConnectionForm(bool alert = false)
        {
            ViewBag.alert = alert;
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
                return RedirectToAction("AdminConnectionForm", "Admin", new {alart = true});
            }
            return RedirectToAction("SignAdmin", "Categories", new { isAdmin = true });
        }

        public IActionResult CheckNewAdminDetailsAndSignToDB(string email, string password, string approverEmail, string approverPassword)
        {

            bool isUser = _userRepository.CheckUser(approverEmail, approverPassword);
            if (!isUser)
            {
                return RedirectToAction("AdminSignUpForm", "Admin", new { error = true });
            }
            else
            {
                _userRepository.AddNewAdmin(email, password);
                return RedirectToAction("AdminConnectionForm", "Admin");
            }
        }




    }
}
