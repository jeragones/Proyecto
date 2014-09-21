using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public class AnalisisController : Controller
    {
        //
        // GET: /Analisis/AddAnalisis

        public ActionResult AddAnalysis()
        {
            return View();
        }

        public ActionResult addCategory() {
            return View();
        }
       
    }
}
