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
    public class LoginImageController : Controller
    {
        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/LoginImage
        public ActionResult Index()
        {
            return View(db.LoginImageTBs.ToList());
        }

        // GET: SMAdm/LoginImage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginImageTB loginImageTB = db.LoginImageTBs.Find(id);
            if (loginImageTB == null)
            {
                return HttpNotFound();
            }
            return View(loginImageTB);
        }

        // GET: SMAdm/LoginImage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMAdm/LoginImage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginImageId,LoginPhoto")] LoginImageTB loginImageTB,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;

                    img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                    loginImageTB.LoginPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                }
                db.LoginImageTBs.Add(loginImageTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginImageTB);
        }

        // GET: SMAdm/LoginImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginImageTB loginImageTB = db.LoginImageTBs.Find(id);
            if (loginImageTB == null)
            {
                return HttpNotFound();
            }
            return View(loginImageTB);
        }

        // POST: SMAdm/LoginImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginImageId,LoginPhoto")] LoginImageTB loginImageTB,HttpPostedFileBase Photo,int id)
        {
            if (ModelState.IsValid)
            {
                var logImage = db.LoginImageTBs.SingleOrDefault(m => m.LoginImageId == id);

                if (Photo != null)
                {

                    if (System.IO.File.Exists(Server.MapPath(logImage.LoginPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(logImage.LoginPhoto));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                    logImage.LoginPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginImageTB);
        }

        // GET: SMAdm/LoginImage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginImageTB loginImageTB = db.LoginImageTBs.Find(id);
            if (loginImageTB == null)
            {
                return HttpNotFound();
            }
            return View(loginImageTB);
        }

        // POST: SMAdm/LoginImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoginImageTB loginImageTB = db.LoginImageTBs.Find(id);
            db.LoginImageTBs.Remove(loginImageTB);
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
