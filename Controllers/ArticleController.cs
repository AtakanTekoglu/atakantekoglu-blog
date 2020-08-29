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
   
    public class ArticleController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

        // GET: Article
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Author).Include(a => a.Category).Include(a => a.Gallery);
            return View(articles.ToList());
        }

       

        // GET: Article/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.GalleryId = new SelectList(db.Galleries, "GalleryId", "Description");
            return View();
        }

        // POST: Article/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleId,Title,Content,ReleaseDate,CategoryId,AuthorId,GalleryId")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName", article.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", article.CategoryId);
            ViewBag.GalleryId = new SelectList(db.Galleries, "GalleryId", "Description", article.GalleryId);
            return View(article);
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName", article.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", article.CategoryId);
            ViewBag.GalleryId = new SelectList(db.Galleries, "GalleryId", "Description", article.GalleryId);
            return View(article);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleId,Title,Content,ReleaseDate,CategoryId,AuthorId,GalleryId")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName", article.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", article.CategoryId);
            ViewBag.GalleryId = new SelectList(db.Galleries, "GalleryId", "Description", article.GalleryId);
            return View(article);
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
