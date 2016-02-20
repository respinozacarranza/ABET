using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UPC.CA.Mockup.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddEditUsuario(Int32? UsuarioId)
        {
            return View();
        }
        public ActionResult ListUsuario(Int32? UsuarioId)
        {
            return View();
        }
        public ActionResult DisableUsuario(Int32? UsuarioId)
        {
            return View();
        }
    }
}