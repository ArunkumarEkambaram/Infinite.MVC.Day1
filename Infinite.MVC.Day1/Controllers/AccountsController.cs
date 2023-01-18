using Infinite.MVC.Day1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Infinite.MVC.Day1.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _dbContext = null;

        public AccountsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpGet]
        public ActionResult Register()
        {
            var roles = _dbContext.Roles.ToList();
            RegisterViewModel registerVM = new RegisterViewModel
            {
                Roles = roles
            };
            return View(registerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    EmailId = registerViewModel.EmailId,
                    Username = registerViewModel.Username,
                    Password = registerViewModel.Password
                };
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                var userId = user.Id;
                UserRolesMapping mapping = new UserRolesMapping()
                {
                    UserId = userId,
                    RoleId = registerViewModel.RoleId
                };
                _dbContext.UserRolesMappings.Add(mapping);
                _dbContext.SaveChanges();
                return RedirectToAction("Login");
            }
            var roles = _dbContext.Roles.ToList();
            RegisterViewModel registerVM = new RegisterViewModel
            {
                Roles = roles
            };
            return View(registerVM);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            var isValidUser = _dbContext.Users.Any(x => x.Username.ToLower() == user.Username.ToLower() && x.Password == user.Password);
            if (isValidUser)
            {
                FormsAuthentication.SetAuthCookie(user.Username, true);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid EmailId or Password");
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}