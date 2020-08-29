using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MyBlogProject.Models.DataContext;
using MyBlogProject.Models.Model;

namespace MyBlogProject.Controllers
{
    
    public class AboutController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

        // GET: About
        public ActionResult Index()
        {
            return View(db.Abouts.ToList().OrderByDescending(x => x.AboutId));
        }

        // GET: About/Create
        [ValidateInput(false)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: About/Create

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AboutId,Title,Content,ImageURL,Skill")] About about, HttpPostedFileBase ImageURL)
        {
            if (ModelState.IsValid)
            {
                if (ImageURL != null)
                {
                    WebImage webImage = new WebImage(ImageURL.InputStream);
                    FileInfo fileInfo = new FileInfo(ImageURL.FileName);
                    string imgName = ImageURL.FileName;
                    webImage.Resize(500, 500);
                    webImage.Save("~/Uploads/About/" + imgName);
                    about.ImageURL = "/Uploads/About/" + imgName;
                }

                db.Abouts.Add(about);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about);
        }

        // GET: About/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: About/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, About about, HttpPostedFileBase ImageURL)
        {
            var ptr = db.Abouts.Where(m => m.AboutId == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (ImageURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(ptr.ImageURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(ptr.ImageURL));
                    }
                    WebImage img = new WebImage(ImageURL.InputStream);
                    FileInfo imgInfo = new FileInfo(ImageURL.FileName);

                    string imgName = ImageURL.FileName + imgInfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/About/" + imgName);

                    ptr.ImageURL = "/Uploads/About/" + imgName;
                }

                ptr.Content = about.Content;
                ptr.Skill = about.Skill;
                ptr.Title = about.Title;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        // GET: About/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: About/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            About about = db.Abouts.Find(id);
            db.Abouts.Remove(about);
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
