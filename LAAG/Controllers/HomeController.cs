using LAAG.Models;
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
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(EmailModel model, string returnUrl)
        {
            if(ModelState.IsValid) {
                MailService insMail = new MailService();
                insMail.contactEmail(model.email, model.name, model.message);
            }
            model.message = "";
            model.email = "";
            model.name = "";
            return View(model);
        }

        public ActionResult blankPage()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}
