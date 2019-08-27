using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace test2.Controllers
{
    public class LanguageChangeController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Change(String LanguageAbbrevation)
        {
            if (LanguageAbbrevation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);

            }
            else
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

            }
            Response.Cookies.Add(new HttpCookie("Language")
            {
                Value = LanguageAbbrevation
            });
            return RedirectToAction("Index", "Home");

        }
    }
}