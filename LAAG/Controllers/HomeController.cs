using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return canSee();
        }

        public ActionResult blankPage()
        {
            return canSee();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult canSee() 
        {
            if (Session["CurrentSession"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
                //return RedirectToAction("Login", "Account");
            }
        }
    }
}
