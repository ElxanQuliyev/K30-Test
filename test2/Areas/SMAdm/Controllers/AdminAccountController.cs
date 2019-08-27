using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using test2.Models;

namespace test2.Areas.SMAdm.Controllers
{

    public class AdminAccountController : Controller
    {
        SmlawDB db = new SmlawDB();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(BasicInfo user)
        {
            var obj = db.BasicInfoes.FirstOrDefault(a => a.AdminEmail == user.AdminEmail);

            if (obj != null)
            {
                if (string.Compare(Crypto.Hash(user.AdminPassword), obj.AdminPassword) == 0)
                {
                    Session["AdminLogged"] = true;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.AdminLoginError = "Email or Password is wrong!";
                }
            }
            else
            {
                ViewBag.AdminLoginError = "Email or Password cannot be empty!";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["AdminLogged"] = null;
            return RedirectToAction("Login", "AdminAccount");
        }
    }
}