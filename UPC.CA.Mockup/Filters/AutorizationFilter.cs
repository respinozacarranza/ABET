using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UPC.CA.Mockup.Helpers;

namespace UPC.CA.Mockup.Filters
{

    public class AuthorizationFilter : AuthorizeAttribute
    {
        private AppRol[] rolesPermitidos;
        private bool tienePermiso;
        public AuthorizationFilter(params AppRol[] rol)
        {
            rolesPermitidos = rol;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var currentRol = httpContext.Session.GetRol();

            foreach (var rol in rolesPermitidos)
            {
                if (currentRol == rol)
                {
                    tienePermiso = true;
                    return true;
                }
            }
            tienePermiso = false;
            return false;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (!filterContext.HttpContext.Session.IsLoggedIn())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary 
                {
                    { "Controller", "Home" },
                    { "Action", "Login" } 
                });
            }
            else
            {
                base.OnAuthorization(filterContext);
                if (!tienePermiso)
                {
                    filterContext.Result = new ViewResult { ViewName = "PermisoDenegado" };
                }
            }
        }

    }
}