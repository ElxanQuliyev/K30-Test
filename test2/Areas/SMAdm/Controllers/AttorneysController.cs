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
    public class AttorneysController : Controller
    {
        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/Attorneys
        public ActionResult Index()
        {
            var attorneyTBs = db.AttorneyTBs.Include(a => a.LanguageTB);
            return View(attorneyTBs.ToList());
        }

        // GET: SMAdm/Attorneys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttorneyTB attorneyTB = db.AttorneyTBs.Find(id);
            if (attorneyTB == null)
            {
                return HttpNotFound();
            }
            return View(attorneyTB);
        }

        // GET: SMAdm/Attorneys/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName");
            return View();
        }

        // POST: SMAdm/Attorneys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttorneyId,FirstName,Lastname,Email,Description,Phone1,Phone2,AttorneyPhoto,WorkSector,LanguageId")] AttorneyTB attorneyTB,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/AttorneyImg/" + newPhoto);
                    attorneyTB.AttorneyPhoto = "/Uploads/AttorneyImg/" + newPhoto;
                }
                db.AttorneyTBs.Add(attorneyTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", attorneyTB.LanguageId);
            return View(attorneyTB);
        }

        // GET: SMAdm/Attorneys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttorneyTB attorneyTB = db.AttorneyTBs.Find(id);
            if (attorneyTB == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", attorneyTB.LanguageId);
            return View(attorneyTB);
        }

        // POST: SMAdm/Attorneys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttorneyId,FirstName,Lastname,Email,Description,Phone1,Phone2,AttorneyPhoto,WorkSector,LanguageId")] AttorneyTB attorneyTB,HttpPostedFileBase Photo,int id)
        {
            if (ModelState.IsValid)
            {

                var attorneyContents = db.AttorneyTBs.SingleOrDefault(m => m.AttorneyId == id);
                if (Photo != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(attorneyContents.AttorneyPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(attorneyContents.AttorneyPhoto));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/AttorneyImg/" + newPhoto);
                    attorneyContents.AttorneyPhoto = "/Uploads/AttorneyImg/" + newPhoto;
                }
                attorneyContents.Description = attorneyTB.Description;
                attorneyContents.WorkSector = attorneyTB.WorkSector;
                attorneyContents.Lastname = attorneyTB.Lastname;
                attorneyContents.FirstName = attorneyTB.FirstName;
                attorneyContents.Email = attorneyTB.Email;
                attorneyContents.Phone1 = attorneyTB.Phone1;
                attorneyContents.Phone2 = attorneyTB.Phone2;
                attorneyContents.LanguageId = attorneyTB.LanguageId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", attorneyTB.LanguageId);
            return View(attorneyTB);
        }

        // GET: SMAdm/Attorneys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttorneyTB attorneyTB = db.AttorneyTBs.Find(id);
            if (attorneyTB == null)
            {
                return HttpNotFound();
            }
            return View(attorneyTB);
        }

        // POST: SMAdm/Attorneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttorneyTB attorneyTB = db.AttorneyTBs.Find(id);
            db.AttorneyTBs.Remove(attorneyTB);
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
