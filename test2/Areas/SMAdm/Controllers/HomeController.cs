using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test2.Areas.SMAdm.Controllers
{
    [AuthorizationFilterController]
    public class HomeController : Controller
    {
        // GET: SMAdm/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}