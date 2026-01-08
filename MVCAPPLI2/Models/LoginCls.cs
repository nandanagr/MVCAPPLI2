using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MVCAPPLI2.Models
{
    public class LoginCls
    {
        [Required(ErrorMessage ="Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Enter password")]
        public string pwd { get; set; }
        public string msg { get; set; }
    }
}