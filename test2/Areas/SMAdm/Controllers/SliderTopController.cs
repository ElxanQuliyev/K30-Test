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
    public class SliderTopController : Controller
    {

        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/SliderTop
        public ActionResult Index()
        {
            var sliderTopTBs = db.SliderTopTBs.Include(s => s.LanguageTB);
            return View(sliderTopTBs.ToList());
        }

        // GET: SMAdm/SliderTop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SliderTopTB sliderTopTB = db.SliderTopTBs.Find(id);
            if (sliderTopTB == null)
            {
                return HttpNotFound();
            }
            return View(sliderTopTB);
        }

        // GET: SMAdm/SliderTop/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName");
            return View();
        }

        // POST: SMAdm/SliderTop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderTopId,SliderContent1,SliderContent2,SliderTopImage,LanguageId")] SliderTopTB sliderTopTB, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/SliderImg/" + newPhoto);
                    sliderTopTB.SliderTopImage = "/Uploads/SliderImg/" + newPhoto;
                }
                db.SliderTopTBs.Add(sliderTopTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", sliderTopTB.LanguageId);
            return View(sliderTopTB);
        }

        // GET: SMAdm/SliderTop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SliderTopTB sliderTopTB = db.SliderTopTBs.Find(id);
            if (sliderTopTB == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", sliderTopTB.LanguageId);
            return View(sliderTopTB);
        }

        // POST: SMAdm/SliderTop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderTopId,SliderContent1,SliderContent2,SliderTopImage,LanguageId")] SliderTopTB sliderTopTB, int id, HttpPostedFileBase SliderTopImage)
        {
            if (ModelState.IsValid)
            {
                var sliderContents = db.SliderTopTBs.SingleOrDefault(m => m.SliderTopId == id);
                if (SliderTopImage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(sliderContents.SliderTopImage)))
                    {
                        System.IO.File.Delete(Server.MapPath(sliderContents.SliderTopImage));
                    }
                    WebImage img = new WebImage(SliderTopImage.InputStream);
                    FileInfo photoInfo = new FileInfo(SliderTopImage.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/SliderImg/" + newPhoto);
                    sliderContents.SliderTopImage = "/Uploads/SliderImg/" + newPhoto;
                }
                sliderContents.SliderContent1 = sliderTopTB.SliderContent1;
                sliderContents.SliderContent2 = sliderTopTB.SliderContent2;
                sliderContents.LanguageId = sliderTopTB.LanguageId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", sliderTopTB.LanguageId);
            return View(sliderTopTB);
        }

        // GET: SMAdm/SliderTop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SliderTopTB sliderTopTB = db.SliderTopTBs.Find(id);
            if (sliderTopTB == null)
            {
                return HttpNotFound();
            }
            return View(sliderTopTB);
        }

        // POST: SMAdm/SliderTop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SliderTopTB sliderTopTB = db.SliderTopTBs.Find(id);
            db.SliderTopTBs.Remove(sliderTopTB);
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
