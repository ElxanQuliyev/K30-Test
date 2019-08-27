using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using test2.Models;

namespace test2.Areas.SMAdm.Controllers
{
    public class AdminArticleController : Controller
    {
        private SmlawDB db = new SmlawDB();

        // GET: SMAdm/AdminArticle
        public ActionResult Index(int Page=1)
        {
            var articles = db.Articles.Include(a => a.LanguageTB);
            return View(articles.OrderByDescending(m => m.ArticleId).ToPagedList(Page, 10));
        }

        // GET: SMAdm/AdminArticle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: SMAdm/AdminArticle/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName");
            return View();
        }

        // POST: SMAdm/AdminArticle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ArticleId,Headline,ArticleContent,IframeLink,Reads,CreateDate,ArticlePhoto,LanguageId")] Article article,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/BlogImage/" + newPhoto);
                    article.ArticlePhoto = "/Uploads/BlogImage/" + newPhoto;
                }
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", article.LanguageId);
            return View(article);
        }

        // GET: SMAdm/AdminArticle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", article.LanguageId);
            return View(article);
        }

        // POST: SMAdm/AdminArticle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ArticleId,Headline,ArticleContent,IframeLink,Reads,CreateDate,ArticlePhoto,LanguageId")] Article article,int id,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                var articleContents = db.Articles.SingleOrDefault(m => m.ArticleId == id);
                if (Photo != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(articleContents.ArticlePhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(articleContents.ArticlePhoto));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    img.Save("~/Uploads/BlogImage/" + newPhoto);
                    articleContents.ArticlePhoto = "/Uploads/BlogImage/" + newPhoto;
                }
                articleContents.Headline = article.Headline;
                articleContents.ArticleContent = article.ArticleContent;
                articleContents.IframeLink = article.IframeLink;

                articleContents.LanguageId = article.LanguageId;
                articleContents.CreateDate = article.CreateDate;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.LanguageTBs, "LanguageId", "CultureName", article.LanguageId);
            return View(article);
        }

        // GET: SMAdm/AdminArticle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: SMAdm/AdminArticle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
