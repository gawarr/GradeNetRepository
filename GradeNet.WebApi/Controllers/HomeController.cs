using GradeNet.Infrastructure.Interfaces;
using GradeNet.Infrastructure.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GradeNet.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private static Logger logger = LogManager.GetLogger("loggerRole");
        private readonly IUserManager _userManager;

        public HomeController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModel user)
        {
            if(String.IsNullOrWhiteSpace(user.Email) || String.IsNullOrWhiteSpace(user.Password))
            {
                ViewBag.Error = "Proszę uzupełnić wszystkie pola.";
                return View();
            }
            if (_userManager.CheckLoginDetails(user))
            {
                logger.Info($"Użytkownik {user.Email} zalogowany.");
                FormsAuthentication.SetAuthCookie(user.Email, false);
                _userManager.LastSuccessfulLoginSet(user.Email);
                return RedirectToAction("Index");
            }
            logger.Info($"Nieskuteczna próba logowania użytkownika {user.Email}.");
            ViewBag.Error = "Błędy login lub hasło.";
            return View();
        }

        [Authorize]
        public ActionResult LogOut()
        {
            logger.Info($"Wylogowywanie użytkownika {User.Identity.Name}.");
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }
    }
}