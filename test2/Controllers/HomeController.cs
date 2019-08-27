using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test2.Models;
using test2.ViewModels.Default;

namespace test2.Controllers
{
    public class HomeController : Controller
    {
        SmlawDB db = new SmlawDB();
        public ActionResult Index()
        {
            var defaultModel = new DefaultViewModel
            {
                sliderTop = db.SliderTopTBs.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).ToList(),
                howWeAre = db.HowWeAreTBs.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).FirstOrDefault(),
                attorney = db.AttorneyTBs.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).ToList(),
                areasOfActivity = db.AreasOfActivities.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).ToList(),
                article = db.Articles.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).ToList(),
                basicInfo = db.BasicInfoes.First()
            };
            return View(defaultModel);
        }

        public ActionResult About()
        {
            var defaultModel = new DefaultViewModel
            {
                AboutImage = db.AboutUsTBs.First(),
                howWeAre = db.HowWeAreTBs.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).FirstOrDefault(),
                basicInfo = db.BasicInfoes.First()
            };

            return View(defaultModel);
        }
        public ActionResult _PostList(Article article)
        {
            var postList = db.Articles.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).OrderByDescending(x => x.ArticleId).Take(5);

            return PartialView(postList);
        }
        public ActionResult _ResentOne(Article article)
        {
            var postList = db.Articles.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).OrderByDescending(x => x.ArticleId).Take(1);

            return PartialView(postList);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Attorneys()
        {
            var defaultModel = new DefaultViewModel
            {
                attorney = db.AttorneyTBs.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).ToList(),
                basicInfo = db.BasicInfoes.First()
            };
            return View(defaultModel);
        }
        public ActionResult AttorneyInfo()
        {
            var defaultModel = new DefaultViewModel
            {
                attorneySingle = db.AttorneyTBs.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).SingleOrDefault(),
                basicInfo = db.BasicInfoes.First()
            };
            return View(defaultModel);
        }
        public ActionResult BlogList(int Page=1)
        {
            var defaultModel = new DefaultViewModel
            {
                ArticleList=db.Articles.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).OrderByDescending(m => m.ArticleId).ToPagedList(Page, 10),
                article = db.Articles.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).OrderByDescending(m => m.ArticleId).Take(5).ToList(),
                newsImage=db.NewsTBs.First(),
                basicInfo = db.BasicInfoes.First()
            };
            return View(defaultModel);
        }

        public ActionResult BlogDetail(int id)
        {
            var defaultModel = new DefaultViewModel
            {
                articleOne = db.Articles.Where(x =>x.ArticleId==id).SingleOrDefault(),
                article = db.Articles.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).OrderByDescending(x=>x.ArticleId).Take(5).ToList(),
                newsImage = db.NewsTBs.First(),
                basicInfo = db.BasicInfoes.First()
            };
            if (defaultModel.articleOne == null)
            {
                return HttpNotFound();
            }
            return View(defaultModel);
        }

        public ActionResult AreasDetail(int id)
        {
            var defaultModel = new DefaultViewModel
            {
                areasOfActivity = db.AreasOfActivities.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).ToList(),
                areasOfDetail = db.AreasOfActivities.Where(x =>x.AreasOfActivityId==id).SingleOrDefault(),
                servicesImage = db.ServicesTBs.First(),
                basicInfo = db.BasicInfoes.First()
            };
            if (defaultModel.areasOfDetail==null)
            {
                return HttpNotFound();
            }
            return View(defaultModel);
        }
        public ActionResult LastAreasOfActivity(AreasOfActivity areasOfActivity)
        {
            var lastpracriceList = db.AreasOfActivities.Where(x => x.LanguageTB.CultureCode == mainLanguage.lb).OrderByDescending(x => x.AreasOfActivityId).Take(5);
            return PartialView(lastpracriceList);
        }
    }
}