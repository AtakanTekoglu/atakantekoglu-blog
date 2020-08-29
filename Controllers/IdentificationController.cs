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
    public class IdentificationController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

        // GET: Identification
        public ActionResult Index()
        {
            return View(db.Identifications.ToList());
        }


        // GET: Identification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Identification/Create
       
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdentificationId,Title,Keywords,Description,LogoURL")] Identification identification, HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid)
            {
                if (LogoURL != null)
                {
                    WebImage webImage = new WebImage(LogoURL.InputStream);
                    FileInfo fileInfo = new FileInfo(LogoURL.FileName);
                    string imgName = LogoURL.FileName;
                    webImage.Resize(270, 229);
                    webImage.Save("~/Uploads/Identification/" + imgName);
                    identification.LogoURL = "/Uploads/Identification/" + imgName;
                }
                db.Identifications.Add(identification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(identification);
        }

        // GET: Identification/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identification identification = db.Identifications.Find(id);
            if (identification == null)
            {
                return HttpNotFound();
            }
            return View(identification);
        }

        // POST: Identification/Edit/5
        
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Identification identification,HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid)
            {

                var ptr = db.Identifications.Where(m => m.IdentificationId == id).FirstOrDefault();
                if (LogoURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(ptr.LogoURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(ptr.LogoURL));
                    }
                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imgInfo = new FileInfo(LogoURL.FileName);

                    string imgName = LogoURL.FileName + imgInfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Identification/" + imgName);

                    ptr.LogoURL = "/Uploads/Identification/" + imgName;
                }

                ptr.Title = identification.Title;
                ptr.Keywords = identification.Keywords;
                ptr.Description = identification.Description;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(identification);
        }

        // GET: Identification/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identification identification = db.Identifications.Find(id);
            if (identification == null)
            {
                return HttpNotFound();
            }
            return View(identification);
        }

        // POST: Identification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Identification identification = db.Identifications.Find(id);
            db.Identifications.Remove(identification);
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
