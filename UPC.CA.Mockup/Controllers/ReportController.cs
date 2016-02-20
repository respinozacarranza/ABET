using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.CA.Mockup.Filters;
using UPC.CA.Mockup.Helpers;

namespace UPC.CA.Mockup.Controllers
{
    public class ReportController : BaseController
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizationFilter(AppRol.Administrador, AppRol.Usuario)]
        public ActionResult ViewReporte()
        {
            return View();
        }
    }
}