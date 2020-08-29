using MyBlogProject.Models.DataContext;
using MyBlogProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogProject.Controllers
{
    
    public class AdminController : Controller
    {
        private BlogDBContext db = new BlogDBContext();
        // GET: Admin
        public ActionResult Index()
        {

            ViewBag.NumberOfArticles = db.Articles.Count();
            ViewBag.NumberOfCategories = db.Categories.Count();
            ViewBag.NumberOfComments = db.Comments.Count();
            ViewBag.NumberOfVisitorComments = db.ContactForms.Count();
            ViewBag.NumberOfUnapprovedComments = db.Comments.Where(x => x.IsApproved == false).Count();
            ViewBag.NumberOfApprovedComments = db.Comments.Where(x => x.IsApproved == true).Count();

            return View();
        }
        //public ActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateInput(false)]

        //public ActionResult Login(Admin admin)
        //{
            
        //    var login = db.Admins.Where(x => x.Email == admin.Email).SingleOrDefault();
        //    if (login.Email == admin.Email && login.Password==admin.Password)
        //    {
        //        Session["adminId"] = login.AdminId;
        //        Session["ePosta"] = login.Email;
        //        return RedirectToAction("Index", "Admin");
        //    }
        //    ViewBag.Alert = "Kullanıcı adı veya şifre yanlış";
        //    return View(admin);
        //}
    }
}