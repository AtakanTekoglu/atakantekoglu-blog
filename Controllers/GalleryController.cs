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
    
    public class GalleryController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

        // GET: Gallery
        public ActionResult Index()
        {
            return View(db.Galleries.ToList());
        }

        // GET: Gallery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // GET: Gallery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gallery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GalleryId,Description,MinPicURL,MidPicURL,BigPicURL,Created")] Gallery gallery, HttpPostedFileBase MinPicURL, HttpPostedFileBase MidPicURL, HttpPostedFileBase BigPicURL)
        {

            

            if (ModelState.IsValid)
            {
                if (MinPicURL != null)
                {
                    WebImage webImage = new WebImage(MinPicURL.InputStream);
                    FileInfo fileInfo = new FileInfo(MinPicURL.FileName);
                    string imgName = MinPicURL.FileName;
                    webImage.Resize(270, 229);
                    webImage.Save("~/Uploads/Gallery/" + imgName);
                    gallery.MinPicURL = "/Uploads/Gallery/" + imgName;
                }
                if (MidPicURL != null)
                {
                    WebImage webImage = new WebImage(MidPicURL.InputStream);
                    FileInfo fileInfo = new FileInfo(MidPicURL.FileName);
                    string imgName = MidPicURL.FileName;
                    webImage.Resize(720, 486);
                    webImage.Save("~/Uploads/Gallery/" + imgName);
                    gallery.MidPicURL = "/Uploads/Gallery/" + imgName;
                }
                if (BigPicURL != null)
                {
                    WebImage webImage = new WebImage(BigPicURL.InputStream);
                    FileInfo fileInfo = new FileInfo(BigPicURL.FileName);
                    string imgName = MidPicURL.FileName;
                    webImage.Resize(960, 640);
                    webImage.Save("~/Uploads/Gallery/" + imgName);
                    gallery.BigPicURL = "/Uploads/Gallery/" + imgName;
                }
                
                db.Galleries.Add(gallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gallery);
        }

        // GET: Gallery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Gallery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Gallery gallery, HttpPostedFileBase MinPicURL, HttpPostedFileBase MidPicURL, HttpPostedFileBase BigPicURL)
        {
            if (ModelState.IsValid)
            {
                var ptr = db.Galleries.Where(m => m.GalleryId == id).FirstOrDefault();
                if (MinPicURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(ptr.MinPicURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(ptr.MinPicURL));
                    }
                    WebImage img = new WebImage(MinPicURL.InputStream);
                    FileInfo imgInfo = new FileInfo(MinPicURL.FileName);

                    string imgName = MinPicURL.FileName + imgInfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Gallery/" + imgName);

                    ptr.MinPicURL = "/Uploads/Gallery/" + imgName;
                }
                if (MidPicURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(ptr.MidPicURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(ptr.MidPicURL));
                    }
                    WebImage img = new WebImage(MidPicURL.InputStream);
                    FileInfo imgInfo = new FileInfo(MidPicURL.FileName);

                    string imgName = MidPicURL.FileName + imgInfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Gallery/" + imgName);

                    ptr.MidPicURL = "/Uploads/Gallery/" + imgName;
                }
                if (BigPicURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(ptr.BigPicURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(ptr.BigPicURL));
                    }
                    WebImage img = new WebImage(BigPicURL.InputStream);
                    FileInfo imgInfo = new FileInfo(BigPicURL.FileName);

                    string imgName = BigPicURL.FileName + imgInfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Gallery/" + imgName);

                    ptr.BigPicURL = "/Uploads/Gallery/" + imgName;
                }
                ptr.Description = gallery.Description;
                ptr.Created = gallery.Created;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallery);
        }

        // GET: Gallery/Delete/5
        public ActionResult Delete(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Gallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery gallery = db.Galleries.Find(id);
            db.Galleries.Remove(gallery);
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
