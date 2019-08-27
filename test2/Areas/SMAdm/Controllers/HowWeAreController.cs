using System;
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
    public class HowWeAreController : Controller
    {
        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/HowWeAre
        public ActionResult Index()
        {
            var howWeAreTBs = db.HowWeAreTBs.Include(h => h.LanguageTB);
            return View(howWeAreTBs.ToList());
        }

        // GET: SMAdm/HowWeAre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HowWeAreTB howWeAreTB = db.HowWeAreTBs.Find(id);
            if (howWeAreTB == null)
            {
                return HttpNotFound();
            }
            return View(howWeAreTB);
        }

        // GET: SMAdm/HowWeAre/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName");
            return View();
        }

        // POST: SMAdm/HowWeAre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HowWeAreID,Description,HPhoto,LanguageId")] HowWeAreTB howWeAreTB,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/HowWePhoto/" + newPhoto);
                    howWeAreTB.HPhoto = "/Uploads/HowWePhoto/" + newPhoto;
                }
                db.HowWeAreTBs.Add(howWeAreTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", howWeAreTB.LanguageId);
            return View(howWeAreTB);
        }

        // GET: SMAdm/HowWeAre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HowWeAreTB howWeAreTB = db.HowWeAreTBs.Find(id);
            if (howWeAreTB == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", howWeAreTB.LanguageId);
            return View(howWeAreTB);
        }

        // POST: SMAdm/HowWeAre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HowWeAreID,Description,HPhoto,LanguageId")] HowWeAreTB howWeAreTB,HttpPostedFileBase Photo,int id)
        {
            if (ModelState.IsValid)
            {
                var sitecontents = db.HowWeAreTBs.SingleOrDefault(m => m.HowWeAreID == id);
                if (Photo != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(sitecontents.HPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(sitecontents.HPhoto));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/HowWePhoto/" + newPhoto);
                    sitecontents.HPhoto = "/Uploads/HowWePhoto/" + newPhoto;
                }
                sitecontents.Description = howWeAreTB.Description;
                sitecontents.LanguageId = howWeAreTB.LanguageId;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", howWeAreTB.LanguageId);
            return View(howWeAreTB);
        }

        // GET: SMAdm/HowWeAre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HowWeAreTB howWeAreTB = db.HowWeAreTBs.Find(id);
            if (howWeAreTB == null)
            {
                return HttpNotFound();
            }
            return View(howWeAreTB);
        }

        // POST: SMAdm/HowWeAre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HowWeAreTB howWeAreTB = db.HowWeAreTBs.Find(id);
            db.HowWeAreTBs.Remove(howWeAreTB);
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
