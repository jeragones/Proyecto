using DotNetOpenAuth.AspNet;
using LAAG.Filters;
using LAAG.Models;
using LAAG.Auxiliares;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace LAAG.Controllers
{
    [Authorize]
    //[InitializeSimpleMembership]
    public class AccountController : Controller
    {  

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
                AuxClass aux = new AuxClass();
                IQueryable<Persona> persona = aux.IsValidUser(model.UserName, model.Password);
                if (persona!=null)
                {
                    foreach(var a in persona){
                        Session["CurrentSession"] = a;
                        if(a.PasswordChange==true){//true=1 -> Necesita Cambiar
                            return RedirectToAction("SetPassword","Account");
                        }
                        else{
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

        //Fill list if type's
        public class TipoUsuario
        {
            public byte tipo { get; set; }
            public String tipoString { get; set; }
        }
        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            LAAG.Persona persona = (LAAG.Persona)Session["CurrentSession"];
            if (Session["CurrentSession"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else if (persona.Tipo == 2)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //ViewData["cbTipo"] = selectList;

                //DataDataContext db = new DataDataContext();
                // Intento de registrar al usuario
                try
                {
                    Persona p = new Persona();
                    p.Nombre = model.Nombre;
                    String[] ape = model.Apellidos.Split(' ');
                    p.Apellido1 = ape[0];
                    if (ape.Length > 1) 
                    {
                        p.Apellido2 = ape[1];
                    }
                    p.Correo = model.Correo;
                    p.Clave = "12345";
                    p.Estado = 0;
                    p.Tipo = model.Tipo;
                    p.NombreUsuario = model.Usuario;
                    p.PasswordChange = true;

                  //  db.Persona.InsertOnSubmit(p);
                //    db.SubmitChanges();
                    ModelState.AddModelError("success", "");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
                catch(SqlException ex){
                    ModelState.AddModelError("", ErrorCodeToString(ex.Number));
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/Profile

        [AllowAnonymous]
        public ActionResult Profile()
        {
            LAAG.Persona persona = (LAAG.Persona)Session["CurrentSession"];
            if (Session["CurrentSession"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
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
        public ActionResult SetPassword(PasswordModel model)
        {
            if (ModelState.IsValid) {
                if (Session["CurrentSession"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    LAAG.Persona persona = (LAAG.Persona)Session["CurrentSession"];
                   // DataDataContext db = new DataDataContext();
                    // Intento de registrar al usuario
                    try
                    {
                        String password = model.Clave;
                       // Persona persona_old = db.Persona.Single(u => u.ID_Persona==persona.ID_Persona);
                       // persona_old.Clave = password;
                       // persona_old.PasswordChange = false;

                       // db.SubmitChanges();
                        ModelState.AddModelError("success", "");
                    }
                    catch (MembershipCreateUserException e)
                    {
                        ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                    }
                    catch (SqlException ex)
                    {
                        ModelState.AddModelError("", ErrorCodeToString(ex.Number));
                    }
                }
            }
            return View("SetPassword");
        }

        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Desasociar la cuenta solo si el usuario que ha iniciado sesión es el propietario
            if (ownerAccount == User.Identity.Name)
            {
                // Usar una transacción para evitar que el usuario elimine su última credencial de inicio de sesión
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage
        public ActionResult Manage(ManageMessageId? message)
        {
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            if (ModelState.IsValid)
            {
            }
            else
            {
            
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
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

        private static string ErrorCodeToString(int error) {
            switch (error)
            { 
                case 2627:
                    return "El nombre de usuario ya está en uso. Seleccione uno distinto";
                default:
                    return "Error desconocido. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema."+" Error:"+error;
            }
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
