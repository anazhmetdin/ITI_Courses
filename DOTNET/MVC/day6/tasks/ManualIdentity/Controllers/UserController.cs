using ManualIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ManualIdentity.Controllers
{
    public class UserController : Controller
    {
        private IdentityContext db = new IdentityContext();

        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Include = "Username,Password,ConfirmPassword,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                var UserIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.username),
                    new Claim(ClaimTypes.Email, user.Email)
                }, "AppCookie");

                Request.GetOwinContext().Authentication.SignIn(UserIdentity);

                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Username,Password")] User user)
        {
            User tUser = db.Users.FirstOrDefault(u => u.username == user.username && u.Password == user.Password);

            if (tUser != null)
            {
                var UserIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, tUser.username),
                    new Claim(ClaimTypes.Email, tUser.Email)
                }, "AppCookie");

                Request.GetOwinContext().Authentication.SignIn(UserIdentity);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Username", "Username or Password dosn't match");
            return View(user);
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppCookie");
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}