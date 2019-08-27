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
    public class RegisterImageController : Controller
    {
        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/RegisterImage
        public ActionResult Index()
        {
            return View(db.RegisterImageTBs.ToList());
        }

        // GET: SMAdm/RegisterImage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterImageTB registerImageTB = db.RegisterImageTBs.Find(id);
            if (registerImageTB == null)
            {
                return HttpNotFound();
            }
            return View(registerImageTB);
        }

        // GET: SMAdm/RegisterImage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMAdm/RegisterImage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegisterImageId,RegisterPhoto")] RegisterImageTB registerImageTB,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;

                    img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                    registerImageTB.RegisterPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                }
                db.RegisterImageTBs.Add(registerImageTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registerImageTB);
        }

        // GET: SMAdm/RegisterImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterImageTB registerImageTB = db.RegisterImageTBs.Find(id);
            if (registerImageTB == null)
            {
                return HttpNotFound();
            }
            return View(registerImageTB);
        }

        // POST: SMAdm/RegisterImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegisterImageId,RegisterPhoto")] RegisterImageTB registerImageTB,int id,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                var regImage = db.RegisterImageTBs.SingleOrDefault(m => m.RegisterImageId == id);

                if (Photo != null)
                {

                    if (System.IO.File.Exists(Server.MapPath(regImage.RegisterPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(regImage.RegisterPhoto));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                    regImage.RegisterPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerImageTB);
        }

        // GET: SMAdm/RegisterImage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterImageTB registerImageTB = db.RegisterImageTBs.Find(id);
            if (registerImageTB == null)
            {
                return HttpNotFound();
            }
            return View(registerImageTB);
        }

        // POST: SMAdm/RegisterImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterImageTB registerImageTB = db.RegisterImageTBs.Find(id);
            db.RegisterImageTBs.Remove(registerImageTB);
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
