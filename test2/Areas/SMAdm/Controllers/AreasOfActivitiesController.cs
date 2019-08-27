using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using test2.Models;

namespace test2.Areas.SMAdm.Controllers
{
    public class AreasOfActivitiesController : Controller
    {
        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/AreasOfActivities
        public ActionResult Index()
        {
            var areasOfActivities = db.AreasOfActivities.Include(a => a.LanguageTB);
            return View(areasOfActivities.ToList());
        }

        // GET: SMAdm/AreasOfActivities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreasOfActivity areasOfActivity = db.AreasOfActivities.Find(id);
            if (areasOfActivity == null)
            {
                return HttpNotFound();
            }
            return View(areasOfActivity);
        }

        // GET: SMAdm/AreasOfActivities/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName");
            return View();
        }

        // POST: SMAdm/AreasOfActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AreasOfActivityId,Headline,Description,AreasIcon,LanguageId")] AreasOfActivity areasOfActivity)
        {
            if (ModelState.IsValid)
            {
                db.AreasOfActivities.Add(areasOfActivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", areasOfActivity.LanguageId);
            return View(areasOfActivity);
        }

        // GET: SMAdm/AreasOfActivities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreasOfActivity areasOfActivity = db.AreasOfActivities.Find(id);
            if (areasOfActivity == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", areasOfActivity.LanguageId);
            return View(areasOfActivity);
        }

        // POST: SMAdm/AreasOfActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AreasOfActivityId,Headline,Description,AreasIcon,LanguageId")] AreasOfActivity areasOfActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areasOfActivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", areasOfActivity.LanguageId);
            return View(areasOfActivity);
        }

        // GET: SMAdm/AreasOfActivities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreasOfActivity areasOfActivity = db.AreasOfActivities.Find(id);
            if (areasOfActivity == null)
            {
                return HttpNotFound();
            }
            return View(areasOfActivity);
        }

        // POST: SMAdm/AreasOfActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AreasOfActivity areasOfActivity = db.AreasOfActivities.Find(id);
            db.AreasOfActivities.Remove(areasOfActivity);
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
