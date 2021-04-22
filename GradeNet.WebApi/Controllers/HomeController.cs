using GradeNet.Infrastructure.Interfaces;
using GradeNet.Infrastructure.ViewModels;
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
        private readonly IUserManager _userManager;

        public HomeController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Index(UserViewModel user)
        {
            if (_userManager.CheckLoginDetails(user))
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return View();
            }
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page. " + User.Identity.Name;

            return View();
        }

        [Authorize(Roles = "testowe_uprawnienie")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }
    }
}