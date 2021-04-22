using GradeNet.Infrastructure.Interfaces;
using GradeNet.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                return RedirectToAction("About");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}