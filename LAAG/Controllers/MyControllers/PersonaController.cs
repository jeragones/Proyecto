using System;
using System.Collections.Generic;
using LAAG;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAAG.Controllers.MyControllers;

namespace LAAG.Controllers
{
    public partial class PersonaController : Controller
    {

        CustomFunction insFunction = new CustomFunction();
        MailService insMail = new MailService();

        //
        // POST: /Persona/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona persona)
        {
            string error = "El nombre de usuario o correo ya existe";
            
                var consult = (from row in db.Persona
                              where row.Correo == persona.Correo ||
                                    row.NombreUsuario == persona.NombreUsuario
                              select row).ToList();
                if (consult.Count == 0) 
                {
                    persona.Clave = insFunction.codeGenerator();
                    db.Persona.Add(persona);
                    db.SaveChanges();
                    insMail.registrationEmail(persona.Correo, persona.NombreUsuario, persona.Clave);
                    return RedirectToAction("Index", "Home");
                }
            
            ModelState.AddModelError("", error);
            return View(persona);
        }


        //
        // POST: /Persona/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(persona);
        }

        //
        // POST: /Persona/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Persona.Find(id);
            db.Persona.Remove(persona);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}