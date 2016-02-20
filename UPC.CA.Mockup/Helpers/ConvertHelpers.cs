using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace UPC.CA.Mockup.Helpers
{
    public static class ConvertHelpers
    {
        private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static Int32 ToInteger(this object val)
        {
            return ConvertHelpers.ToInteger(val, 0);
        }

        public static Int32 ToInteger(this object val, Int32 def)
        {
            try
            {
                Int32 reval = 0;

                if (Int32.TryParse(val.ToString(), out reval))
                    return reval;
            }
            catch (Exception)
            {
            }

            return def;
        }

        public static Decimal ToDecimal(this object val)
        {
            return ConvertHelpers.ToDecimal(val, 0);
        }

        public static Decimal ToDecimal(this object val, Decimal def)
        {
            try
            {
                Decimal reval = 0;

                if (Decimal.TryParse(val.ToString(), out reval))
                    return reval;
            }
            catch (Exception)
            {
            }

            return def;
        }


        public static long ToLong(this Decimal val)
        {
            return (long)val;
        }


        public static long ToJsonDateTime(this DateTime val)
        {
            return ((long)(val - unixEpoch).TotalSeconds) * 1000;
        }

        public static String ToFullCallendarDate(this DateTime val)
        {
            return val.ToString("yyyy-MM-dd hh:mm:ss");
        }

        public static DateTime ToDateTime(this object val)
        {
            return ConvertHelpers.ToDateTime(val, DateTime.MinValue);
        }
        public static String ToDateTimeFormatByCulture(this DateTime val, CultureInfo culture)
        {
            var format = culture.DateTimeFormat.ShortDatePattern.ToString();
            return val.ToString(format);
        }
        
        public static DateTime ToDateTime(this object val, DateTime def)
        {
            try
            {
                DateTime reval = DateTime.MinValue;

                if (DateTime.TryParse(val.ToString(), out reval))
                    return reval;
            }
            catch (Exception)
            {
            }

            return def;
        }
        
        public static Boolean ToBoolean(this object val)
        {
            return ConvertHelpers.ToBoolean(val, false);
        }

        public static Boolean ToBoolean(this object val, Boolean def)
        {
            try
            {
                Boolean reval = false;

                if (Boolean.TryParse(val.ToString(), out reval))
                    return reval;
            }
            catch (Exception)
            {
            }

            return def;
        }

        public static string ToJson(this object val)
        {
            return JsonConvert.SerializeObject(val, Formatting.Indented, new JsonSerializerSettings() { PreserveReferencesHandling = PreserveReferencesHandling.None, ReferenceLoopHandling = ReferenceLoopHandling.Ignore, ObjectCreationHandling = ObjectCreationHandling.Reuse });
        }

        public static MvcHtmlString ToHTMLJson(this object val)
        {
            return MvcHtmlString.Create(val.ToJson());
        }
    }

}