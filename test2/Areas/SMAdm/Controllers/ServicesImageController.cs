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
    public class ServicesImageController : Controller
    {
        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/ServicesImage
        public ActionResult Index()
        {
            return View(db.ServicesTBs.ToList());
        }

        // GET: SMAdm/ServicesImage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesTB servicesTB = db.ServicesTBs.Find(id);
            if (servicesTB == null)
            {
                return HttpNotFound();
            }
            return View(servicesTB);
        }

        // GET: SMAdm/ServicesImage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMAdm/ServicesImage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicesId,ServicesPhoto")] ServicesTB servicesTB,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;

                    img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                    servicesTB.ServicesPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                }
                db.ServicesTBs.Add(servicesTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicesTB);
        }

        // GET: SMAdm/ServicesImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesTB servicesTB = db.ServicesTBs.Find(id);
            if (servicesTB == null)
            {
                return HttpNotFound();
            }
            return View(servicesTB);
        }

        // POST: SMAdm/ServicesImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicesId,ServicesPhoto")] ServicesTB servicesTB,HttpPostedFileBase Photo,int id)
        {

            if (ModelState.IsValid)
            {
                var articles = db.ServicesTBs.SingleOrDefault(m => m.ServicesId == id);

                if (Photo != null)
                {

                    if (System.IO.File.Exists(Server.MapPath(articles.ServicesPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(articles.ServicesPhoto));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                    articles.ServicesPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicesTB);
        }

        // GET: SMAdm/ServicesImage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicesTB servicesTB = db.ServicesTBs.Find(id);
            if (servicesTB == null)
            {
                return HttpNotFound();
            }
            return View(servicesTB);
        }

        // POST: SMAdm/ServicesImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicesTB servicesTB = db.ServicesTBs.Find(id);
            db.ServicesTBs.Remove(servicesTB);
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
