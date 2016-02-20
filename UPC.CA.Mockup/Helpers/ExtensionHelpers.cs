using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace UPC.CA.Mockup.Helpers
{
    public static class ExtensionsHelpers
    {
        /// <summary>
        ///   Guarda archivo xml dependiendo del objeto y el tipo definido.
        /// </summary>
        public static void SaveAsXML(this object obj, String fileName)
        {
            var xmlRequest = new StreamWriter(fileName);
            var xmlFileRequest = new XmlSerializer(obj.GetType());
            xmlFileRequest.Serialize(xmlRequest, obj);
            xmlRequest.Close();
        }

        public static Boolean IsBetween(this DateTime val, DateTime Start, DateTime End)
        {
            return val >= Start && val <= End;
        }

        /// <summary>
        ///   Remueve digitos con acentos dentro de una cadena.
        /// </summary>
        public static String RemoveDiacritics(this String srt)
        {
            var normalizedString = srt.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();
            foreach (var character in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(character);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(character);
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        ///   Remueve espacios en blanco y digitos con acentos dentro de una cadena.
        /// </summary>
        public static String TrimRemoveDiacritics(this String srt)
        {
            try
            {
                return RemoveDiacritics(srt.Trim()).DeleteDotAndComma().ToUpper();
            }
            catch (Exception)
            {
                return "";
                throw;
            }
        }

        /// <summary>
        ///   Calcula la cifra de recondeo para la moneda peruana con la regla .05 centimos
        /// </summary>
        public static Decimal GetPeruCentsRound(this Decimal val)
        {
            val = val.RoundTwoDecimalPlaces();
            var value = val.ToString().Split('.')[1].Substring(1).ToDecimal();
            if (value == 5 || value == 0)
                return new Decimal(0);
            else if (value < 5)
                return value / (new Decimal(100));
            else
                return (value - 5) / (new Decimal(100));
        }

        /// <summary>
        ///  Devuelve un string con formato #.00 
        /// </summary>
        public static String ToStringDecimalCommaSeparate(this Decimal val)
        {
            //return val.ToString("#,##0.00");
            return val.ToString("F", CultureInfo.GetCultureInfo(ConstantHelpers.CULTURE.ESPANOL));
        }


        /// <summary>
        ///  Elimina los puntos y comas de un arreglo 
        /// </summary>
        public static String DeleteDotAndComma(this String str)
        {
            str = str.Replace(".", "");
            str = str.Replace(",", "");
            return str;
        }

        public static void CreateDirectory(this DirectoryInfo directory)
        {
            if (!directory.Exists)
                directory.Create();
        }

        /// <summary>
        ///   Redondea decimal a 2 campos
        /// </summary>
        public static Decimal RoundTwoDecimalPlaces(this Decimal val)
        {
            return Decimal.Round(val, 2, MidpointRounding.AwayFromZero);
        }
    }
}