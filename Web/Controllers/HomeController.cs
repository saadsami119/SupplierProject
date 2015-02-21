using Infrastructure.Models;
using Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "UserName,Password")] Users user)
        {
            if (this.userService.VerifyUser(user))
            {
                TempData["Message"] = "Success";
            }
            else
            {
                TempData["Message"] = "Failure";
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

    }
}
