﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using LAAG.Filters;
using LAAG.Models;
using System.Data;
using System.Data.Entity;
using LAAG.AuxFiles;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace LAAG.Controllers
{
    [Authorize]
    //[InitializeSimpleMembership]
    public class AccountController : Controller
    {
        private AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();
        private AuxClass insAux = new AuxClass();
        private MailService insMail = new MailService();

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            Session["CurrentSession"] = null;
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            Session["CurrentSession"] = null;
            if (ModelState.IsValid)
            {
                IQueryable<Persona> persona = insAux.IsValidUser(model.UserName, model.Password);
                if (persona != null)
                {
                    foreach (var a in persona)
                    {
                        Session["CurrentSession"] = a;
                        if (a.PasswordChange == true)
                        {//true=1 -> Necesita Cambiar
                            return RedirectToAction("SetPassword", "Account");
                        }
                        else
                        {
                            return RedirectToLocal(returnUrl);
                        }
                    }
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            ModelState.AddModelError("", "El nombre de usuario o la contraseña especificados son incorrectos.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            Session["CurrentSession"] = null;
            return RedirectToAction("Login()", "Account");
        }


        //
        // GET: /Account/Users

        [AllowAnonymous]
        public ActionResult Result()
        {
            //var users = from x in db.Personas select x;
            return View("Result","");
        }

        //
        // GET: /Account/ListaUsuarios

        [AllowAnonymous]
        public ActionResult Search()
        {
            //db.Persona.All();
            return View();
        }

        //
        // GET: Account/SetPassword
        [AllowAnonymous]
        public ActionResult SetPassword()
        {
            if (Session["CurrentSession"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View("SetPassword");
            }
        }

        //
        //POST: /Account/SetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SetPassword(Persona model)
        {
            //if (ModelState.IsValid)
           // {
                if (Session["CurrentSession"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    LAAG.Persona persona = (LAAG.Persona)Session["CurrentSession"];
                     AGRONOMICOSDBEntities db = new AGRONOMICOSDBEntities();
                    // Intento de registrar al usuario
                    try
                    {
                        var personaOld = db.Persona
                       .Where(i => i.ID_Persona == persona.ID_Persona)
                       .Single();

                        String password = model.Clave;
                        personaOld.Clave = password;
                        personaOld.PasswordChange = false;

                        db.Entry(personaOld).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Home.Index");
                    }
                    catch (MembershipCreateUserException e)
                    {
                        ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                            }
                        }
                    }
                }
           // }
            return View("SetPassword");
        }

        //
        //GET: /Account/Profile
        [AllowAnonymous]
        public ActionResult Profile()
        {
            LAAG.Persona personaT = (LAAG.Persona)Session["CurrentSession"];
            if (Session["CurrentSession"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Persona persona = db.Persona.Find(personaT.ID_Persona);
                if (persona == null)
                {
                    return HttpNotFound();
                }
                return View("Details",  persona);
            }
        }

        //
        //GET: /Account/EditProfile
        [AllowAnonymous]
        public ActionResult EditProfile()
        {
            LAAG.Persona personaT = (LAAG.Persona)Session["CurrentSession"];
            if (Session["CurrentSession"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Persona persona = db.Persona.Find(personaT.ID_Persona);
                if (persona == null)
                {
                    return HttpNotFound();
                }
                return View("EditProfile", persona);
            }
        }

        //
        //POST: /Account/EditProfile
        [HttpPost]
        [AllowAnonymous]
        public ActionResult EditProfile(Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(persona);
        }


        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "La contraseña se ha cambiado."
                : message == ManageMessageId.SetPasswordSuccess ? "Su contraseña se ha establecido."
                : message == ManageMessageId.RemoveLoginSuccess ? "El inicio de sesión externo se ha quitado."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // ChangePassword iniciará una excepción en lugar de devolver false en determinados escenarios de error.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "La contraseña actual es incorrecta o la nueva contraseña no es válida.");
                    }
                }
            }
            else
            {
                // El usuario no dispone de contraseña local, por lo que debe quitar todos los errores de validación generados por un
                // campo OldPassword
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", String.Format("No se puede crear una cuenta local. Es posible que ya exista una cuenta con el nombre \"{0}\".", User.Identity.Name));
                    }
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/RecoverPassword

        [AllowAnonymous]
        public ActionResult RecoverPassword(string returnUrl)
        {
            return View();
        }

        //
        // POST: /Account/RecoverPassword

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RecoverPassword(RecoverPassword model, string returnUrl)
        {
            IQueryable<Persona> persona = insAux.GetPerson(model.UserName);
                if (persona != null)
                {
                    foreach (var a in persona)
                    {
                        insMail.recoverUser(a.Correo, a.NombreUsuario, a.Clave);
                    }
                }
            return RedirectToLocal(returnUrl);
        }

        #region Aplicaciones auxiliares
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // Vaya a http://go.microsoft.com/fwlink/?LinkID=177550 para
            // obtener una lista completa de códigos de estado.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "El nombre de usuario ya existe. Escriba un nombre de usuario diferente.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Ya existe un nombre de usuario para esa dirección de correo electrónico. Escriba una dirección de correo electrónico diferente.";

                case MembershipCreateStatus.InvalidPassword:
                    return "La contraseña especificada no es válida. Escriba un valor de contraseña válido.";

                case MembershipCreateStatus.InvalidEmail:
                    return "La dirección de correo electrónico especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "La respuesta de recuperación de la contraseña especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "La pregunta de recuperación de la contraseña especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidUserName:
                    return "El nombre de usuario especificado no es válido. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.ProviderError:
                    return "El proveedor de autenticación devolvió un error. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";

                case MembershipCreateStatus.UserRejected:
                    return "La solicitud de creación de usuario se ha cancelado. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";

                default:
                    return "Error desconocido. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";
            }
        }
        #endregion
    }
}
