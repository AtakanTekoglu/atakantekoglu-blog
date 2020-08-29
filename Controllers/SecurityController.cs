using MyBlogProject.Models.DataContext;
using MyBlogProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBlogProject.Controllers
{
    
    public class SecurityController : Controller
    {
        private BlogDBContext db = new BlogDBContext();
        // GET: Security
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Admin admin)
        {
            var user = db.Admins.FirstOrDefault(m => m.Email == admin.Email && m.Password == admin.Password);
            if (user != null)
            {
                //Böyle bir admin var
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Index","Admin");
            }
            else
            {
                ViewBag.Message = "Invalid Email or Password";
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}