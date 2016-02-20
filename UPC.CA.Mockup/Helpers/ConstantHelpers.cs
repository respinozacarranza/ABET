using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UPC.CA.Mockup.Helpers
{
    public static class ConstantHelpers
    {
        #region ESTADO
        public static class ESTADO
        {
            public const String ACTIVO = "ACT";
            public const String INACTIVO = "INA";
            public const String REVISADO = "REV";
            public const String APROBADO = "APR";
        }
        #endregion

        #region ROL
        public static class ROL
        {
            public const String ADMINISTRADOR = "ADM";
            public const String DIRECTOR = "DIR";
            public const String COORDINADOR = "COR";
            public const String DOCENTE = "DOC";
        }
        #endregion

        #region CULTURE
        public static class CULTURE
        {
            public const String ESPANOL = "es-PE";
            public const String INGLES = "en-US";
        }
        #endregion

        #region PAGINATION
        public const Int32 PAGE_SIZE = 10;
        public static PagedListRenderOptions TwitterBootstrapPagerAligned
        {
            get
            {
                return new PagedListRenderOptions()
                {
                    DisplayLinkToFirstPage = PagedListDisplayMode.Never,
                    DisplayLinkToLastPage = PagedListDisplayMode.Never,
                    DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
                    DisplayLinkToNextPage = PagedListDisplayMode.Always,
                    DisplayLinkToIndividualPages = true,
                    ContainerDivClasses = null,
                    UlElementClasses = new[] { "pagination" },
                    ClassToApplyToFirstListItemInPager = "first",
                    ClassToApplyToLastListItemInPager = "last",
                    LinkToFirstPageFormat = "<i class='md md-more-horiz'><i>",
                    LinkToPreviousPageFormat = "<i class='md md-chevron-left'></i>",
                    LinkToIndividualPageFormat = "{0}",
                    LinkToNextPageFormat = "<i class='md md-chevron-right'></i>",
                    LinkToLastPageFormat = "<i class='md md-more-horiz'><i>"
                };
            }
        }
        #endregion
    }
}