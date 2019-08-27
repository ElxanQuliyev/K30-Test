using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Helpers;
using System.Web.Mvc;
using test2.Models;

namespace test2.Areas.SMAdm.Controllers
{
    //[AuthorizationFilterController]
    public class BasicInfoController : Controller
    {
        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/BasicInfo
        public ActionResult Index()
        {
            return View(db.BasicInfoes.ToList());
        }

        // GET: SMAdm/BasicInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasicInfo basicInfo = db.BasicInfoes.Find(id);
            if (basicInfo == null)
            {
                return HttpNotFound();
            }
            return View(basicInfo);
        }

      
        // GET: SMAdm/BasicInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasicInfo basicInfo = db.BasicInfoes.Find(id);
            if (basicInfo == null)
            {
                return HttpNotFound();
            }
            return View(basicInfo);
        }

        // POST: SMAdm/BasicInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BasicInfoId,Email,Location,Phone,FbLogin,TwitterLogin,InstaLogin,LinkedLogin,OpenDate,CloseDate,AdminEmail,AdminPassword")] BasicInfo basicInfo)
        {
            if (ModelState.IsValid)
            {
                basicInfo.AdminPassword = Crypto.Hash(basicInfo.AdminPassword);
                db.Entry(basicInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basicInfo);
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
