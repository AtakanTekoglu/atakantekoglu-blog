using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBlogProject.Models.DataContext;
using MyBlogProject.Models.Model;

namespace MyBlogProject.Controllers
{
    
    public class ContactFormsController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

        // GET: ContactForms
        public ActionResult Index()
        {
            return View(db.ContactForms.ToList());
        }

        // GET: ContactForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = db.ContactForms.Find(id);
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }


        // GET: ContactForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = db.ContactForms.Find(id);
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // POST: ContactForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactForm contactForm = db.ContactForms.Find(id);
            db.ContactForms.Remove(contactForm);
            db.SaveChanges();
            return RedirectToAction("Index");
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
