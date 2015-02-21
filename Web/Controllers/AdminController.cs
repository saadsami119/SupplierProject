using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Models;
using Infrastructure.Service;
using System.Web.Helpers;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        private IUserService userService;

        public AdminController(IUserService userService)
        {
            this.userService = userService;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(Users user)
        {   try
            {
                if (ModelState.IsValid)
                {
                    userService.RegisterUser(user);
                }
            }
            catch
            {
                Response.StatusCode = 500;
            }

                return View();
        }

        public ActionResult DisplayUsers()
        {
           IEnumerable<Users> allUsers = userService.GetAllUsers();
           return View(allUsers);
        }

        public void DeleteUser(int Id)
        {
            try 
            {
                userService.DeleteUser(Id);
                
            }
            catch 
            {
                Response.StatusCode = 500;
            }
           
           
        }

    }
}
