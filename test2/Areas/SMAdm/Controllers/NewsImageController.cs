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
using test2.Models;

namespace test2.Areas.SMAdm.Controllers
{
    [AuthorizationFilterController]
    public class NewsImageController : Controller
    {
        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/NewsImage
        public ActionResult Index()
        {
            return View(db.NewsTBs.ToList());
        }

        // GET: SMAdm/NewsImage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsTB newsTB = db.NewsTBs.Find(id);
            if (newsTB == null)
            {
                return HttpNotFound();
            }
            return View(newsTB);
        }

        // GET: SMAdm/NewsImage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMAdm/NewsImage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsId,NewsPhoto")] NewsTB newsTB,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;

                    img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                    newsTB.NewsPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                }
                db.NewsTBs.Add(newsTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsTB);
        }

        // GET: SMAdm/NewsImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsTB newsTB = db.NewsTBs.Find(id);
            if (newsTB == null)
            {
                return HttpNotFound();
            }
            return View(newsTB);
        }

        // POST: SMAdm/NewsImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsId,NewsPhoto")] NewsTB newsTB,int id,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                var articles = db.NewsTBs.SingleOrDefault(m => m.NewsId == id);

                if (Photo != null)
                {

                    if (System.IO.File.Exists(Server.MapPath(articles.NewsPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(articles.NewsPhoto));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                    articles.NewsPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsTB);
        }

        // GET: SMAdm/NewsImage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsTB newsTB = db.NewsTBs.Find(id);
            if (newsTB == null)
            {
                return HttpNotFound();
            }
            return View(newsTB);
        }

        // POST: SMAdm/NewsImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsTB newsTB = db.NewsTBs.Find(id);
            db.NewsTBs.Remove(newsTB);
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
