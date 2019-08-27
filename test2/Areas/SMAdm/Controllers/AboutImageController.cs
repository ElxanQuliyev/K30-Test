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
    public class AboutImageController : Controller
    {
        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/AboutImage
        public ActionResult Index()
        {
            return View(db.AboutUsTBs.ToList());
        }

        // GET: SMAdm/AboutImage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUsTB aboutUsTB = db.AboutUsTBs.Find(id);
            if (aboutUsTB == null)
            {
                return HttpNotFound();
            }
            return View(aboutUsTB);
        }

        // GET: SMAdm/AboutImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUsTB aboutUsTB = db.AboutUsTBs.Find(id);
            if (aboutUsTB == null)
            {
                return HttpNotFound();
            }
            return View(aboutUsTB);
        }

        // POST: SMAdm/AboutImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AboutUsId,AboutUsPhoto")] AboutUsTB aboutUsTB,int id,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                var articles = db.AboutUsTBs.SingleOrDefault(m => m.AboutUsId == id);

                if (Photo != null)
                {

                    if (System.IO.File.Exists(Server.MapPath(articles.AboutUsPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(articles.AboutUsPhoto));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/AboutPhoto/" + newPhoto);
                    articles.AboutUsPhoto = "/Uploads/AboutPhoto/" + newPhoto;
                }
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutUsTB);
        }

        // GET: SMAdm/AboutImage/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AboutUsTB aboutUsTB = db.AboutUsTBs.Find(id);
        //    if (aboutUsTB == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(aboutUsTB);
        //}


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
