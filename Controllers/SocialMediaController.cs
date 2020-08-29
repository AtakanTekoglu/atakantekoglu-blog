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
 
    public class SocialMediaController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

        // GET: SocialMedia
        public ActionResult Index()
        {
            return View(db.SocialMedias.ToList());
        }


        // GET: SocialMedia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialMedia/Create
       
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SocialMediaId,Instagram,Linkedin,Github")] SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                db.SocialMedias.Add(socialMedia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialMedia);
        }

        // GET: SocialMedia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialMedia = db.SocialMedias.Find(id);
            if (socialMedia == null)
            {
                return HttpNotFound();
            }
            return View(socialMedia);
        }

        // POST: SocialMedia/Edit/5
        
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SocialMediaId,Instagram,Linkedin,Github")] SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialMedia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialMedia);
        }

        // GET: SocialMedia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialMedia = db.SocialMedias.Find(id);
            if (socialMedia == null)
            {
                return HttpNotFound();
            }
            return View(socialMedia);
        }

        // POST: SocialMedia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialMedia socialMedia = db.SocialMedias.Find(id);
            db.SocialMedias.Remove(socialMedia);
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
