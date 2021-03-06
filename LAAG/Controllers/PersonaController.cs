﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LAAG;
using System.Web.Mvc;

namespace LAAG.Controllers
{
    public partial class PersonaController : Controller
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();

        //
        // GET: /Persona/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Persona/Clientes

        public ActionResult Clientes(int tipoP = 2)
        {
            if(!canView()){
                return RedirectToAction("Login", "Account");
            }
            var query = db.Persona.Where(p => p.Tipo == tipoP).ToList();
            return View("Index",query);
        }

        //
        // GET: /Persona/Empleados

        public ActionResult Empleados(int tipoP = 1)
        {
            if (!canView())
            {
                return RedirectToAction("Login", "Account");
            }
            var query = db.Persona.Where(p => p.Tipo == tipoP).ToList();
            return View("Index",query);
        }

        //
        // GET: /Persona/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!canView())
            {
                return RedirectToAction("Login", "Account");
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // GET: /Persona/Create

        public ActionResult Create()
        {
            if (!canView())
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }


        //
        // GET: /Persona/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!canView())
            {
                return RedirectToAction("Login", "Account");
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }


        //
        // GET: /Persona/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!canView())
            {
                return RedirectToAction("Login", "Account");
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public Boolean canView() {
            if (Session["CurrentSession"] != null)
            {
                return true;
            }
            else { 
                return false;
            }
        }
    }
}