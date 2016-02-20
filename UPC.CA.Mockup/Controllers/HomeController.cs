using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using UPC.CA.Mockup.Filters;
using UPC.CA.Mockup.Helpers;
using UPC.CA.Mockup.ViewModels.Home;

namespace UPC.CA.Mockup.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session.IsLoggedIn())
            {
                return RedirectToAction("Dashboard");
            }
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ContentResult KeepAlive()
        {
            Session.Set(SessionKey.UsuarioId, Session.GetUsuarioId());
            return Content("");
        }

        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    PostMessage(MessageType.Error, "Credenciales no Válidas");
                    return View(model);
                }

                if (!String.IsNullOrEmpty(model.Usuario))
                {
                    switch (model.Usuario)
                    {
                        case "admin":
                            Session.Set(SessionKey.Rol, AppRol.Administrador);
                            break;
                        case "coordinador":
                            Session.Set(SessionKey.Rol, AppRol.Usuario);
                            break;
                        case "docente":
                            Session.Set(SessionKey.Rol, AppRol.Docente);
                            break;
                        default:
                            PostMessage(MessageType.Error, "Credenciales no Válidas");
                            return View(model);
                    }
                    Session.Set(SessionKey.UsuarioId, 1);
                    Session.Set(SessionKey.Rol, AppRol.Administrador);
                    Session.Set(SessionKey.Nombre, model.Usuario);

                    return RedirectToAction("Dashboard");
                }
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, ex.Message);
                return View(model);
            }

            PostMessage(MessageType.Error, "Credenciales no Válidas");
            return View(model);
        }
        public ActionResult Dashboard()
        {
            if (Session.IsLoggedIn())
            {
                return View();
            }
            Session.Clear();
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult ChangeIdioma(String Idioma)
        {
            Session.Set(SessionKey.Culture, new CultureInfo(Idioma));
            var lastUrl = Request.UrlReferrer.AbsoluteUri;
            return Redirect(lastUrl);
        }
    }
}