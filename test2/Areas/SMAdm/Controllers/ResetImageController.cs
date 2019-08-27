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
    public class ResetImageController : Controller
    {
        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/ResetImage
        public ActionResult Index()
        {
            return View(db.ResetImageTBs.ToList());
        }

        // GET: SMAdm/ResetImage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResetImageTB resetImageTB = db.ResetImageTBs.Find(id);
            if (resetImageTB == null)
            {
                return HttpNotFound();
            }
            return View(resetImageTB);
        }

        // GET: SMAdm/ResetImage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMAdm/ResetImage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResetImageId,ResetPhoto")] ResetImageTB resetImageTB,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;

                    img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                    resetImageTB.ResetPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                }
                db.ResetImageTBs.Add(resetImageTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resetImageTB);
        }

        // GET: SMAdm/ResetImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResetImageTB resetImageTB = db.ResetImageTBs.Find(id);
            if (resetImageTB == null)
            {
                return HttpNotFound();
            }
            return View(resetImageTB);
        }

        // POST: SMAdm/ResetImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResetImageId,ResetPhoto")] ResetImageTB resetImageTB,int id,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                var resImg = db.ResetImageTBs.SingleOrDefault(m => m.ResetImageId == id);

                if (Photo != null)
                {

                    if (System.IO.File.Exists(Server.MapPath(resImg.ResetPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(resImg.ResetPhoto));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                    resImg.ResetPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resetImageTB);
        }

        // GET: SMAdm/ResetImage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResetImageTB resetImageTB = db.ResetImageTBs.Find(id);
            if (resetImageTB == null)
            {
                return HttpNotFound();
            }
            return View(resetImageTB);
        }

        // POST: SMAdm/ResetImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResetImageTB resetImageTB = db.ResetImageTBs.Find(id);
            db.ResetImageTBs.Remove(resetImageTB);
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
