using MyBlogProject.Models.DataContext;
using MyBlogProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MyBlogProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

       
        public ActionResult Index()
        {
            ViewBag.ContentSEO = db.Identifications.SingleOrDefault();
           
            var blog = db.Articles.Include("Author").Include("Category").ToList().OrderByDescending(x => x.ArticleId);
            return View(blog);
        }

        public ActionResult AboutFixed()
        {
            
            ViewBag.AuthorPicture = db.Authors.Select(x => x.Gallery.MinPicURL).FirstOrDefault();
            ViewBag.Social = db.SocialMedias.SingleOrDefault();
            return View();
        }

        
        public ActionResult GetArticleByCategory(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var article = db.Articles.Include("Category").Include("Author").OrderByDescending(x => x.ArticleId).Where(x => x.Category.CategoryId == id).ToList();
            ViewBag.CtgName = db.Categories.Where(x => x.CategoryId == id).SingleOrDefault();

            return View(article);
        }


        
        public ActionResult About()
        {
            var etiketler = db.Abouts.SingleOrDefault();
            List<string> ytn = etiketler.Skill.Split(',').ToList();
            ViewBag.comma = ytn;
            return View(etiketler);
        }
        
        public ActionResult BlogDetay(int id)
        {
            // var blog = db.Articles.Include("Author").Include("Category").ToList();
            db.Configuration.LazyLoadingEnabled = false;
            ViewBag.AuthorPicture = db.Authors.Select(x => x.Gallery.MidPicURL).FirstOrDefault();
            ViewBag.LatestArticles = db.Articles.ToList().OrderByDescending(x => x.ArticleId).Take(3);
            var blog = db.Articles.Include("Author").Include("Category").Include("Comments").Where(x => x.ArticleId == id).FirstOrDefault();
            return View(blog);
        }

        
        public JsonResult CommentSection(string nameSurname,string eMail,string content,int articleId)
        {
            if (content==null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            db.Comments.Add(new Comment { NameSurname = nameSurname, Email = eMail, Content = content, ArticleId = articleId, IsApproved = false });
            db.SaveChanges();
            return Json(false, JsonRequestBehavior.AllowGet);
        }
      
        public ActionResult Iletisim()
        { 
            return View(db.Contacts.SingleOrDefault());
        }

        [HttpGet]
        
        public ActionResult IletisimForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IletisimForm([Bind(Include = "ContactFormId,Namesurname,Email,Subject,Message")] ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                db.ContactForms.Add(contactForm);
                db.SaveChanges();
                return RedirectToAction("Iletisim", "Home");
            }
            return View(contactForm);
        }

      
        //[ValidateInput(false)]
        //[HttpPost]
        //public ActionResult Iletisim(string name = null, string email = null, string subject = null, string message = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (name!=null && email!=null)
        //        {
        //            WebMail.SmtpServer = "smtp.gmail.com";
        //            WebMail.EnableSsl = true;
        //            WebMail.UserName = "atakantekogluegitim@gmail.com";
        //            WebMail.Password = "Password was here";
        //            WebMail.SmtpPort = 587;
                    
        //            WebMail.Send("atakantekoglu@gmail.com", subject, email + "-" + message);
        //            ViewBag.Uyari = "Mesajınız başarı ile gönderilmiştir.";
        //            Response.Redirect("/Home/Iletisim/");
        //        }
        //        else
        //        {
        //            ViewBag.Uyari = "Hata oluştu. Tekrar Deneyiniz.";
        //        }
        //    }

        //    return View();
        //}
    }
}