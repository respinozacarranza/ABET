using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace UPC.CA.Mockup.Helpers
{
    public enum AppRol
    {
        Administrador, 
        Docente,
        Usuario
    }

    public enum SessionKey
    {
        UsuarioId,
        Nombre,
        Apellido,
        Codigo,
        Email,
        Culture,
        Rol
    }

    public static class SessionHelper
    {
        #region Set & Get
        public static object Get(HttpSessionStateBase Session, SessionKey Key)
        {
            return Session[Key.ToString()];
        }
        public static object Get(HttpSessionState Session, SessionKey Key)
        {
            return Session[Key.ToString()];
        }
        public static void Set(this HttpSessionStateBase Session, SessionKey Key, object value)
        {
            Session[Key.ToString()] = value;
        }
        public static void Set(this HttpSessionState Session, SessionKey Key, object value)
        {
            Session[Key.ToString()] = value;
        }
        #endregion

        #region IsLoggedIn
        public static Boolean IsLoggedIn(this HttpSessionState Session)
        {
            return Get(Session, SessionKey.Rol) != null;
        }

        public static Boolean IsLoggedIn(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.Rol) != null;
        }
        #endregion     

        public static Int32? GetUsuarioId(this HttpSessionStateBase Session)
        {
            return (Int32?)Get(Session, SessionKey.UsuarioId);
        }
        public static Int32? GetUsuarioId(this HttpSessionState Session)
        {
            return (Int32?)Get(Session, SessionKey.UsuarioId);
        }

        public static String GetNombre(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.Nombre).ToString();
        }
        public static String GetNombre(this HttpSessionState Session)
        {
            return Get(Session, SessionKey.Nombre).ToString();
        }

        public static String GetApellido(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.Apellido).ToString();
        }
        public static String GetApellido(this HttpSessionState Session)
        {
            return Get(Session, SessionKey.Apellido).ToString();
        }

        public static object GetCulture(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.Culture);
        }
        public static object GetCulture(this HttpSessionState Session)
        {
            return Get(Session, SessionKey.Culture);
        }

        public static AppRol GetRol(this HttpSessionStateBase Session)
        {
            return (AppRol)Get(Session, SessionKey.Rol);
        }
        public static AppRol GetRol(this HttpSessionState Session)
        {
            return (AppRol)Get(Session, SessionKey.Rol);
        }

        public static object GetEmail(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.Email).ToString();
        }
        public static object GetEmail(this HttpSessionState Session)
        {
            return Get(Session, SessionKey.Email).ToString();
        }

        public static object GetCodigo(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.Codigo).ToString();
        }
        public static object GetCodigo(this HttpSessionState Session)
        {
            return Get(Session, SessionKey.Codigo).ToString();
        }

    }
}