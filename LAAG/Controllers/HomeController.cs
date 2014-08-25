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
        
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }



        public ActionResult blankPage()
        {
            ViewBag.Message = "Hola";
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
                return RedirectToAction("Login", "Account");
            }
        }

    }
}
