﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UPC.CA.Mockup.Controllers
{
    public class ErrorController : BaseController
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult InternalServerError()
        {
            return View();
        }
    }
}