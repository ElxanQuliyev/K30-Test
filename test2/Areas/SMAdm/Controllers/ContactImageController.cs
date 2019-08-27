using System;
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
    public class ContactImageController : Controller
    {
        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/ContactImage
        public ActionResult Index()
        {
            return View(db.ContactTBs.ToList());
        }

        // GET: SMAdm/ContactImage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactTB contactTB = db.ContactTBs.Find(id);
            if (contactTB == null)
            {
                return HttpNotFound();
            }
            return View(contactTB);
        }

        // GET: SMAdm/ContactImage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMAdm/ContactImage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactId,ContactPhoto")] ContactTB contactTB,HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {
                WebImage img = new WebImage(Photo.InputStream);
                FileInfo photoInfo = new FileInfo(Photo.FileName);
                string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;

                img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                contactTB.ContactPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                db.ContactTBs.Add(contactTB);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
            return View(contactTB);
        }

        // GET: SMAdm/ContactImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactTB contactTB = db.ContactTBs.Find(id);
            if (contactTB == null)
            {
                return HttpNotFound();
            }
            return View(contactTB);
        }

        // POST: SMAdm/ContactImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactId,ContactPhoto")] ContactTB contactTB,int id,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                var contImg = db.ContactTBs.SingleOrDefault(m => m.ContactId == id);

                if (Photo != null)
                {

                    if (System.IO.File.Exists(Server.MapPath(contImg.ContactPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(contImg.ContactPhoto));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                    contImg.ContactPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactTB);
        }

        // GET: SMAdm/ContactImage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactTB contactTB = db.ContactTBs.Find(id);
            if (contactTB == null)
            {
                return HttpNotFound();
            }
            return View(contactTB);
        }

        // POST: SMAdm/ContactImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactTB contactTB = db.ContactTBs.Find(id);
            db.ContactTBs.Remove(contactTB);
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
