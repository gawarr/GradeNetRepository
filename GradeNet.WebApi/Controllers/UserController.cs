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
    [Authorize]
    public class UserController : Controller
    {
        private static Logger logger = LogManager.GetLogger("loggerRole");
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public ActionResult UserProfile()
        {
            logger.Debug($"Pobiera dane użytkownia {User.Identity.Name}.");
            UserDetailsViewModel userModel = _userManager.GetUserDetails(User.Identity.Name);

            return View(userModel);
        }
    }
}