using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UPC.CA.Mockup.ViewModels.Home
{
    public class LoginViewModel
    {
        [Required]
        public String Usuario { get; set; }
        public String Password { get; set; }
    }
}