using LAAG.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.App_Code
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
            return View();
        }

        public ActionResult canSee() 
        {
            return View();
            //if (Session["CurrentSession"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Account");
            //}
        }

        //public ActionResult contact()
        //{
            
        //    return null;
        //}
    }
}
